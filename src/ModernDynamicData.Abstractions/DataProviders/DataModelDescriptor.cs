using System;
using System.Collections.ObjectModel;

namespace ModernDynamicData.Abstractions.DataProviders
{
    /// <summary>
    /// Provides a base class for Dynamic Data model providers.
    /// </summary>
    public abstract class DataModelDescriptor
    {
        /// <summary>
        /// When overridden in a derived class, creates an instance of the data context.
        /// </summary>
        /// <returns>
        /// An instance of the data context.
        /// </returns>
        public abstract object CreateContext();
        /// <summary>
        /// When overridden in a derived class, gets the list of tables that are exposed by the data model.
        /// </summary>
        /// <returns>
        /// The list of tables that are exposed by the data model.
        /// </returns>
        public abstract ReadOnlyCollection<TableDescriptor> Tables { get; }
        /// <summary>
        /// Gets the type of the data context.
        /// </summary>
        /// <returns>
        /// The type of the data context.
        /// </returns>
        public virtual Type DataModelType { get; protected set; }
        /// <summary>
        /// Gets the type of the data context.
        /// </summary>
        /// <returns>
        /// The type of the data context.
        /// </returns>
        public virtual string DataModelName { get; protected set; }
    }
}
