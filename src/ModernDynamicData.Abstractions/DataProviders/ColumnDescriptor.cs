using System;

namespace ModernDynamicData.Abstractions.DataProviders
{
    /// <summary>
    ///     Base provider class for columns.
    ///     Each provider type (e.g. Linq To Sql, Entity Framework, 3rd party) extends this class.
    /// </summary>
    public abstract class ColumnDescriptor
    {
        /// <summary>
        ///     ctor
        /// </summary>
        /// <param name="table">the table this column belongs to</param>
        protected ColumnDescriptor(TableDescriptor table)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            Table = table;
        }

        /// <summary>
        ///     The name of the column
        /// </summary>
        public virtual string Name { get; protected set; }

        /// <summary>
        ///     The CLR type of the column
        /// </summary>
        public virtual Type ColumnType { get; protected set; }

        /// <summary>
        ///     The table that this column belongs to
        /// </summary>
        public TableDescriptor Table { get; private set; }

        /// <summary>
        ///     readable representation
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Name ?? base.ToString();
    }
}