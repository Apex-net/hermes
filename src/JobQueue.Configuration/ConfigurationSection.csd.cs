//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Apexnet.JobQueue.Configuration
{
    
    
    /// <summary>
    /// The RedisStorage Configuration Section.
    /// </summary>
    public partial class RedisStorage : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the RedisStorage Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string RedisStorageSectionName = "redisStorage";
        
        /// <summary>
        /// The XML path of the RedisStorage Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string RedisStorageSectionPath = "HangfireStorage/redisStorage";
        
        /// <summary>
        /// Gets the RedisStorage instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public static global::Apexnet.JobQueue.Configuration.RedisStorage Instance
        {
            get
            {
                return ((global::Apexnet.JobQueue.Configuration.RedisStorage)(global::System.Configuration.ConfigurationManager.GetSection(global::Apexnet.JobQueue.Configuration.RedisStorage.RedisStorageSectionPath)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Apexnet.JobQueue.Configuration.RedisStorage.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::Apexnet.JobQueue.Configuration.RedisStorage.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region ConnectionString Property
        /// <summary>
        /// The XML name of the <see cref="ConnectionString"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string ConnectionStringPropertyName = "connectionString";
        
        /// <summary>
        /// Gets or sets the ConnectionString.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.ComponentModel.DescriptionAttribute("The ConnectionString.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Apexnet.JobQueue.Configuration.RedisStorage.ConnectionStringPropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual string ConnectionString
        {
            get
            {
                return ((string)(base[global::Apexnet.JobQueue.Configuration.RedisStorage.ConnectionStringPropertyName]));
            }
            set
            {
                base[global::Apexnet.JobQueue.Configuration.RedisStorage.ConnectionStringPropertyName] = value;
            }
        }
        #endregion
        
        #region RedisStorageOptions Property
        /// <summary>
        /// The XML name of the <see cref="RedisStorageOptions"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string RedisStorageOptionsPropertyName = "redisStorageOptions";
        
        /// <summary>
        /// Gets or sets the RedisStorageOptions.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.ComponentModel.DescriptionAttribute("The RedisStorageOptions.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Apexnet.JobQueue.Configuration.RedisStorage.RedisStorageOptionsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Apexnet.JobQueue.Configuration.RedisStorageOptions RedisStorageOptions
        {
            get
            {
                return ((global::Apexnet.JobQueue.Configuration.RedisStorageOptions)(base[global::Apexnet.JobQueue.Configuration.RedisStorage.RedisStorageOptionsPropertyName]));
            }
            set
            {
                base[global::Apexnet.JobQueue.Configuration.RedisStorage.RedisStorageOptionsPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Apexnet.JobQueue.Configuration
{
    
    
    /// <summary>
    /// The RedisStorageOptions Configuration Element.
    /// </summary>
    public partial class RedisStorageOptions : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Db Property
        /// <summary>
        /// The XML name of the <see cref="Db"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string DbPropertyName = "db";
        
        /// <summary>
        /// Gets or sets the Db.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.ComponentModel.DescriptionAttribute("The Db.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Apexnet.JobQueue.Configuration.RedisStorageOptions.DbPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::System.Int32? Db
        {
            get
            {
                return ((global::System.Int32?)(base[global::Apexnet.JobQueue.Configuration.RedisStorageOptions.DbPropertyName]));
            }
            set
            {
                base[global::Apexnet.JobQueue.Configuration.RedisStorageOptions.DbPropertyName] = value;
            }
        }
        #endregion
        
        #region InvisibilityTimeout Property
        /// <summary>
        /// The XML name of the <see cref="InvisibilityTimeout"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string InvisibilityTimeoutPropertyName = "invisibilityTimeout";
        
        /// <summary>
        /// Gets or sets the InvisibilityTimeout.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.ComponentModel.DescriptionAttribute("The InvisibilityTimeout.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Apexnet.JobQueue.Configuration.RedisStorageOptions.InvisibilityTimeoutPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::System.TimeSpan? InvisibilityTimeout
        {
            get
            {
                return ((global::System.TimeSpan?)(base[global::Apexnet.JobQueue.Configuration.RedisStorageOptions.InvisibilityTimeoutPropertyName]));
            }
            set
            {
                base[global::Apexnet.JobQueue.Configuration.RedisStorageOptions.InvisibilityTimeoutPropertyName] = value;
            }
        }
        #endregion
        
        #region Prefix Property
        /// <summary>
        /// The XML name of the <see cref="Prefix"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        internal const string PrefixPropertyName = "prefix";
        
        /// <summary>
        /// Gets or sets the Prefix.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.7")]
        [global::System.ComponentModel.DescriptionAttribute("The Prefix.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Apexnet.JobQueue.Configuration.RedisStorageOptions.PrefixPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string Prefix
        {
            get
            {
                return ((string)(base[global::Apexnet.JobQueue.Configuration.RedisStorageOptions.PrefixPropertyName]));
            }
            set
            {
                base[global::Apexnet.JobQueue.Configuration.RedisStorageOptions.PrefixPropertyName] = value;
            }
        }
        #endregion
    }
}
