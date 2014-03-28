namespace WP8Bootstrap.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;

    /// <summary>
    /// Represents a dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed and allows sorting.
    /// </summary>
    /// Source:  http://stackoverflow.com/a/11191500
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class SortableObservableCollection<T> : ObservableCollection<T>
    {
        /// <summary>
        /// Sorts the items of the collection in ascending order according to a key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="keySelector">A function to extract a key from an item.</param>
        public void Sort<TKey>(Func<T, TKey> keySelector)
        {
            this.InternalSort(Items.OrderBy(keySelector));
        }

        /// <summary>
        /// Sorts the items of the collection in ascending order according to a key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="keySelector">A function to extract a key from an item.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
        public void Sort<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.InternalSort(Items.OrderBy(keySelector, comparer));
        }

        /// <summary>
        /// Sorts the items of the collection in descending order according to a key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="keySelector">A function to extract a key from an item.</param>
        public void SortDescending<TKey>(Func<T, TKey> keySelector)
        {
            this.InternalSort(Items.OrderByDescending(keySelector));
        }

        /// <summary>
        /// Sorts the items of the collection in descending order according to a key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
        /// <param name="keySelector">A function to extract a key from an item.</param>
        /// <param name="comparer">An <see cref="IComparer{T}"/> to compare keys.</param>
        public void SortDescending<TKey>(Func<T, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.InternalSort(Items.OrderByDescending(keySelector, comparer));
        }

        /// <summary>
        /// Moves the items of the collection so that their orders are the same as those of the items provided.
        /// </summary>
        /// <param name="sortedItems">An <see cref="IEnumerable{T}"/> to provide item orders.</param>
        private void InternalSort(IEnumerable<T> sortedItems)
        {
            List<T> sortedItemsList = sortedItems.ToList();

            foreach (var item in sortedItemsList)
            {
                this.Move(this.IndexOf(item), sortedItemsList.IndexOf(item));
            }

            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
