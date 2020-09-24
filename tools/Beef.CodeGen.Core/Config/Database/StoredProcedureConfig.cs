﻿// Copyright (c) Avanade. Licensed under the MIT License. See https://github.com/Avanade/Beef

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Beef.CodeGen.Config.Database
{
    /// <summary>
    /// Represents the stored procedure configuration.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [ClassSchema("StoredProcedure", Title = "The **StoredProcedure** is used to identify a database `Stored Procedure` and define its code-generation characteristics.", Description = "", Markdown = "")]
    [CategorySchema("Key", Title = "Provides the **key** configuration.")]
    [CategorySchema("Auth", Title = "Provides the **Authorization** configuration.")]
    public class StoredProcedureConfig : ConfigBase<CodeGenConfig, TableConfig>
    {
        #region Key

        /// <summary>
        /// Gets or sets the name of the `StoredProcedure` in the database.
        /// </summary>
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "The name of the `StoredProcedure` in the database.", IsMandatory = true, IsImportant = true)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the stored procedure operation type.
        /// </summary>
        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "The stored procedure operation type.", IsImportant = true,
            Options = new string[] { "Get", "GetColl", "Create", "Update", "Upsert", "Delete", "Merge" },
            Description = "Defaults to `GetColl`.")]
        public string? Type { get; set; }

        /// <summary>
        /// Indicates whether standardized paging support should be added.
        /// </summary>
        [JsonProperty("paging", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "Indicates whether standardized paging support should be added.", IsImportant = true,
            Description = "This only applies where the stored procedure operation `Type` is `GetColl`.")]
        public bool? Paging { get; set; }

        /// <summary>
        /// Gets or sets the SQL statement to perform the reselect after a `Create`, `Update` or `Upsert` stored procedure operation `Type`.
        /// </summary>
        [JsonProperty("reselectStatement", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "The SQL statement to perform the reselect after a `Create`, `Update` or `Upsert` stored procedure operation `Type`.",
            Description = "Defaults to `[{{Table.Schema}}].[sp{{Table.Name}}Get]` passing the primary key column(s).")]
        public string? ReselectStatement { get; set; }

        /// <summary>
        /// Indicates whether to select into a `#TempTable` to allow other statements to get access to the selected data. 
        /// </summary>
        [JsonProperty("intoTempTable", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "Indicates whether to select into a `#TempTable` to allow other statements to get access to the selected data.",
            Description = "A `Select * from #TempTable` is also performed (code-generated) where the stored procedure operation `Type` is `GetColl`.")]
        public bool? IntoTempTable { get; set; }

        /// <summary>
        /// Gets or sets the column names (comma separated) to be used in the `Merge` statement to determine whether to insert, update or delete.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "DTO.")]
        [JsonProperty("mergeOverrideIdentityColumns", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "The column names to be used in the `Merge` statement to determine whether to insert, update or delete.",
            Description = "This is used to override the default behaviour of using the identity column(s).")]
        public List<string>? MergeOverrideIdentityColumns { get; set; }

        /// <summary>
        /// Gets or sets the table hints using the SQL Server `WITH()` statement; the value specified will be used as-is; e.g. `NOLOCK` will result in `WITH(NOLOCK)`.
        /// </summary>
        [JsonProperty("withHints", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Key", Title = "the table hints using the SQL Server `WITH()` statement; the value specified will be used as-is; e.g. `NOLOCK` will result in `WITH(NOLOCK)`.")]
        public string? WithHints { get; set; }

        /// <summary>
        /// Gets or sets the permission (full name being `name.action`) override to be used for security permission checking.
        /// </summary>
        [JsonProperty("permission", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertySchema("Auth", Title = "The name of the `StoredProcedure` in the database.")]
        public string? Permission { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the corresponding <see cref="ParameterConfig"/> collection.
        /// </summary>
        [JsonProperty("parameters", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertyCollectionSchema(Title = "The corresponding `Parameter` collection.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This is appropriate for what is obstensibly a DTO.")]
        public List<ParameterConfig>? Parameters { get; set; }

        /// <summary>
        /// Gets or sets the corresponding <see cref="WhereConfig"/> collection.
        /// </summary>
        [JsonProperty("where", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertyCollectionSchema(Title = "The corresponding `Where` collection.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This is appropriate for what is obstensibly a DTO.")]
        public List<WhereConfig>? Where { get; set; }

        /// <summary>
        /// Gets or sets the corresponding <see cref="OrderByConfig"/> collection.
        /// </summary>
        [JsonProperty("orderby", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertyCollectionSchema(Title = "The corresponding `OrderBy` collection.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This is appropriate for what is obstensibly a DTO.")]
        public List<OrderByConfig>? OrderBy { get; set; }

        /// <summary>
        /// Gets or sets the corresponding <see cref="ExecuteConfig"/> collection.
        /// </summary>
        [JsonProperty("execute", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [PropertyCollectionSchema(Title = "The corresponding `Execute` collection.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "This is appropriate for what is obstensibly a DTO.")]
        public List<ExecuteConfig>? Execute { get; set; }

        /// <summary>
        /// Gets the "Before" <see cref="ExecuteConfig"/> collection.
        /// </summary>
        public List<ExecuteConfig>? ExecuteBefore => Execute!.Where(x => x.Location == "Before").ToList();

        /// <summary>
        /// Gets the "After" <see cref="ExecuteConfig"/> collection.
        /// </summary>
        public List<ExecuteConfig>? ExecuteAfter => Execute!.Where(x => x.Location == "After").ToList();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Globalization", "CA1308:Normalize strings to uppercase", Justification = "Requirement is for lowercase.")]
        protected override void Prepare()
        {
            Type = DefaultWhereNull(Type, () => "GetColl");
            ReselectStatement = DefaultWhereNull(ReselectStatement, () => $"[{Parent!.Schema}].[sp{Parent.Name}Get]");
            Permission = DefaultWhereNull(Permission?.ToUpperInvariant(), () => Parent!.Permission == null ? null : Parent!.Permission!.ToUpperInvariant() + "." + Type switch
            {
                "Delete" => "DELETE",
                "Get" => "READ",
                "GetColl" => "READ",
                _ => "WRITE"
            });

            if (Parameters == null)
                Parameters = new List<ParameterConfig>();

            foreach (var parameter in Parameters)
            {
                parameter.Prepare(Root!, this);
            }

            if (Where == null)
                Where = new List<WhereConfig>();

            foreach (var where in Where)
            {
                where.Prepare(Root!, this);
            }

            if (OrderBy == null)
                OrderBy = new List<OrderByConfig>();

            foreach (var orderby in OrderBy)
            {
                orderby.Prepare(Root!, this);
            }

            if (Execute == null)
                Execute = new List<ExecuteConfig>();

            foreach (var execute in Execute)
            {
                execute.Prepare(Root!, this);
            }
        }
    }
}