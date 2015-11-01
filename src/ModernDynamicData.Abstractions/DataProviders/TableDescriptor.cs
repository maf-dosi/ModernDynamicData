using System;
using System.Collections.ObjectModel;

namespace ModernDynamicData.Abstractions.DataProviders
{
    /// <summary>
    ///     Base provider class for tables.
    ///     Each provider type (e.g. Linq To Sql, Entity Framework, 3rd party) extends this class.
    /// </summary>
    public abstract class TableDescriptor
    {
        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="model">the model this table belongs to</param>
        protected TableDescriptor(DataModelDescriptor model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            DataModel = model;
        }

        /// <summary>
        ///     The name of the table.  Typically, this is the name of the property in the data context class
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        ///     The collection of columns in this table
        /// </summary>
        public abstract ReadOnlyCollection<ColumnDescriptor> Columns { get; }

        /// <summary>
        ///     The data model provider that this table is part of
        /// </summary>
        public DataModelDescriptor DataModel { get; internal set; }

        /// <summary>
        ///     readable representation
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name ?? base.ToString();
    }
}