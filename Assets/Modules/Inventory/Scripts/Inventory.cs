using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Modules.Inventories
{
    public class Inventory : IEnumerable<Item>
    {
        private sealed class ItemAreaComparer : IComparer<Item>
        {
            public int Compare(Item x, Item y)
            {
                int xArea = x.Size.x * x.Size.y;
                int yArea = y.Size.x * y.Size.y;

                return yArea.CompareTo(xArea);
            }
        }
        
        private static readonly IComparer<Item> AreaComparer = new ItemAreaComparer();
        
        private int _width;
        private int _height;
        
        private Dictionary<Item, Vector2Int> _items = new();
        private Item[,] _grid;

        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        public int Width => _width;
        public int Height => _height;
        public int Count => _items.Count;

        public Inventory(int width, int height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException();
            
            _width = width;
            _height = height;
            _grid = new Item[width, height];
        }

        public Inventory(
            int width,
            int height,
            params KeyValuePair<Item, Vector2Int>[] items
        ) : this(width, height, (IEnumerable<KeyValuePair<Item, Vector2Int>>)items)
        {
        }

        public Inventory(
            int width,
            int height,
            IEnumerable<KeyValuePair<Item, Vector2Int>> items
        ) : this(width, height)
        {
            if (items == null)
                throw new ArgumentNullException();

            foreach (var item in items) 
                AddItem(item.Key, item.Value);
        }

        public Inventory(
            int width,
            int height,
            params Item[] items
        ) : this(width,height, (IEnumerable<Item>) items)
        {
        }

        public Inventory(
            int width,
            int height,
            IEnumerable<Item> items
        ) : this(width, height)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
                AddItem(item);
        }

        /// <summary>
        /// Creates new inventory 
        /// </summary>
        public Inventory(Inventory inventory) : this(
            inventory?._width ?? throw new ArgumentNullException(), 
            inventory._height,
            inventory._items)
        {}
        
        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool CanAddItem(Item item, Vector2Int position) => 
            CanAddItem(item, position.x, position.y);

        public bool CanAddItem(Item item, int startX, int startY)
        {
            return CheckForValidItem(item) &&
                   IsPositionInbound(startX, startY) &&
                   !_items.ContainsKey(item) &&
                   item.Size.x + startX <= _width && item.Size.y + startY <= _height &&
                   IsFreeSpace(item, startX, startY);
        }

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(Item item)
        {
            return CheckForValidItem(item) &&
                   FindFreePosition(item, out var position) &&
                   CanAddItem(item, position);
        }

        /// <summary>
        /// Adds an item on a specified position
        /// </summary>
        public bool AddItem(Item item, Vector2Int position)
        {
            if (!CheckForValidItem(item) ||
                _items.ContainsKey(item) ||
                !IsValidPosition(item, position) ||
                !IsFreeSpace(position.x, position.y, position.x + item.Size.x, position.y + item.Size.y))
                return false;

            AddItemInternal(item, position);
            return true;
        }

        public bool AddItem(Item item, int startX, int startY) => 
            AddItem(item, new Vector2Int(startX, startY));

        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(Item item)
        {
            if (!CheckForValidItem(item) ||
                _items.ContainsKey(item) || 
                !FindFreePosition(item.Size, out Vector2Int position))
                return false;

            AddItemInternal(item, position);
            return true;
        }

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(Item item, out Vector2Int position) =>
            FindFreePosition(item.Size, out position);
        
        public bool FindFreePosition(Vector2Int size, out Vector2Int position)
        {
            if (size.x <= 0 || size.y <= 0)
                throw new ArgumentException();
            
            position = new Vector2Int();

            if (size.x > _width || size.y > _height)
                return false;
            
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (IsFreeSpace(j, i, j + size.x, i + size.y))
                    {
                        position.x = j;
                        position.y = i;
                        return true;
                    }
                }
            }

            return false;
        }

        public bool FindFreePosition(int sizeX, int sizeY, out Vector2Int position) =>
            FindFreePosition(new Vector2Int(sizeX, sizeY), out position);

        /// <summary>
        /// Checks if the specified element exists
        /// </summary>
        public bool Contains(Item item) => 
            item != null && _items.ContainsKey(item);

        /// <summary>
        /// Checks if the specified position is occupied
        /// </summary>
        public bool IsOccupied(Vector2Int position) => 
            !IsFree(position);

        public bool IsOccupied(int x, int y) => 
            IsOccupied(new Vector2Int(x, y));

        /// <summary>
        /// Checks if the specified position is free
        /// </summary>
        public bool IsFree(Vector2Int position)
        {
            if (!IsPositionInbound(position))
                return false;
            
            return _grid[position.x, position.y] == null;
        }
        
        public bool IsFree(int x, int y) => 
            IsFree(new Vector2Int(x, y));

        /// <summary>
        /// Removes specified item
        /// </summary>
        public bool RemoveItem(Item item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!_items.Remove(item, out var position))
                return false;

            RemoveItemInternal(item, position);
            return true;
        }

        public bool RemoveItem(Item item, out Vector2Int position)
        {
            position = default;
            
            if (!CheckForValidItem(item) || 
                !_items.Remove(item, out position))
                return false;

            RemoveItemInternal(item, position);
            return true;
        }

        /// <summary>
        /// Returns an item at specified position 
        /// </summary>
        public Item GetItem(Vector2Int position) => 
            GetItem(position.x, position.y);

        public Item GetItem(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                throw new IndexOutOfRangeException();
            
            return !IsPositionInbound(x, y) ? null : _grid[x, y];
        }

        public bool TryGetItem(Vector2Int position, out Item item) =>
            TryGetItem(position.x, position.y, out item);

        public bool TryGetItem(int x, int y, out Item item)
        {
            if (x < 0 || x >= _width ||
                y < 0 || y >= _height)
            {
                item = null;
                return false;
            }
            
            item = GetItem(x, y);

            return item != null;
        }

        /// <summary>
        /// Returns positions of a specified item 
        /// </summary>
        public Vector2Int[] GetPositions(Item item)
        {
            if (item == null)
                throw new NullReferenceException(nameof(item));

            if (!_items.ContainsKey(item))
                throw new KeyNotFoundException(nameof(item));

            Vector2Int[] itemPositions = new Vector2Int[item.Size.x * item.Size.y];
            Vector2Int itemStartPosition = _items[item];

            for (int i = 0; i < item.Size.x; i++)
            for (int j = 0; j < item.Size.y; j++) 
                itemPositions[j + i * item.Size.y] = new Vector2Int(itemStartPosition.x + i, itemStartPosition.y + j);

            return itemPositions;
        }

        public bool TryGetPositions(Item item, out Vector2Int[] positions)
        {
            positions = null;
            
            if (item == null || 
                !_items.ContainsKey(item))
                return false;
            
            positions = GetPositions(item);

            return positions != null;
        }

        /// <summary>
        /// Clears all items 
        /// </summary>
        public void Clear()
        {
            if (_items.Count == 0)
                return;
            
            _items.Clear();
            Array.Clear(_grid, 0, _grid.Length);
            OnCleared?.Invoke();
        }

        /// <summary>
        /// Returns count of items with a specified name
        /// </summary>
        public int GetItemCount(string name)
        {
            int count = 0;
            foreach (var item in _items)
            {
                if (string.Equals(name, item.Key.Name))
                    count++;
            }

            return count;
        }

        public bool MoveItem(Item item, Vector2Int position)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (!_items.ContainsKey(item) || 
                !IsValidPosition(item, position))
                return false;
            
            for (int x = position.x; x < position.x + item.Size.x; x++)
            {
                for (int y = position.y; y < position.y + item.Size.y; y++)
                {
                    var occupyingItem = _grid[x, y];

                    if (occupyingItem != null && 
                        !Equals(occupyingItem, item))
                        return false;
                }
            }
            
            RemoveItemFromGrid(item, position);
            _items[item] = position;
            AddItemOnGrid(item, position);
            
            OnMoved?.Invoke(item, position);
            return true;
        }

        /// <summary>
        /// Rearranges an inventory space with max free slots 
        /// </summary>
        public void OptimizeSpace()
        {
            if (_items.Count == 0)
                return;

            List<Item> sortedItems = ListPool<Item>.Get();

            try
            {
                sortedItems.AddRange(_items.Keys);

                sortedItems.Sort(AreaComparer);
                
                ClearWithoutEvents();

                foreach (var item in sortedItems)
                {
                    if (FindFreePosition(item, out var position))
                    {
                        _items.Add(item, position);
                        AddItemOnGrid(item, position);
                    }
                }
            }
            finally
            {
                ListPool<Item>.Release(sortedItems);
            }
        }

        /// <summary>
        /// Iterates by all items 
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();

        public IEnumerator<Item> GetEnumerator() => 
            _items.Keys.GetEnumerator();

        /// <summary>
        /// Copies items to a specified matrix
        /// </summary>
        public void CopyTo(Item[,] matrix) => 
            Array.Copy(_grid, matrix, _grid.Length);

        /// <summary>
        /// Returns an inventory matrix in string format
        /// </summary>
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    var item = GetItem(i, j);
                    result += item != null ? $"{item.Name} " : "null ";
                }
                result += "\n";
            }
            return result;
        }

        private bool IsPositionInbound(Vector2Int position) => 
            IsPositionInbound(position.x, position.y);

        private bool IsPositionInbound(int x, int y)
        {
            if (x >= _width || y >= _height)
                throw new IndexOutOfRangeException();

            if (x < 0 || y < 0)
                return false;

            return true;
        }

        private bool IsValidPosition(Item item, Vector2Int position)
        {
            int endX = position.x + item.Size.x - 1;
            int endY = position.y + item.Size.y - 1;

            return
                position.x >= 0 &&
                position.y >= 0 &&
                endX < _width &&
                endY < _height;
        }
        
        private bool IsFreeSpace(Item item, Vector2Int position) =>
            IsFreeSpace(item, position.x, position.y);
        
        private bool IsFreeSpace(Item item, int x, int y) => 
            IsFreeSpace(x, y, x + item.Size.x, y + item.Size.y);
        
        private bool IsFreeSpace(int startX, int startY, int endX, int endY)
        {
            if (endX > _width || endY > _height)
                return false;
            
            for (int i = startX; i < endX; i++)
            {
                for (int j = startY; j < endY; j++)
                {
                    if (!IsFree(i, j))
                        return false;
                }
            }

            return true;
        }
        
        private bool CheckForValidItem(Item item)
        {
            if (item == null) 
                return false;

            if (item.Size.x <= 0 || item.Size.y <= 0)
                throw new ArgumentException();

            return true;
        }

        private void AddItemOnGrid(Item item, Vector2Int position)
        {
            for (int x = position.x; x < position.x + item.Size.x; x++)
            for (int y = position.y; y < position.y + item.Size.y; y++)
                _grid[x, y] = item;
        }

        private void RemoveItemFromGrid(Item item, Vector2Int position)
        {
            for (int x = position.x; x < position.x + item.Size.x; x++)
            for (int y = position.y; y < position.y + item.Size.y; y++)
                _grid[x, y] = null;
        }

        private void RemoveItemInternal(Item item, Vector2Int position)
        {
            RemoveItemFromGrid(item, position);
            OnRemoved?.Invoke(item, position);
        }

        private void AddItemInternal(Item item, Vector2Int position)
        {
            _items.Add(item, position);
            AddItemOnGrid(item, position);
            OnAdded?.Invoke(item, position);
        }
        
        private void ClearWithoutEvents()
        {
            if (_items.Count == 0)
                return;
            
            _items.Clear();
            Array.Clear(_grid, 0, _grid.Length);
        }
    }
}