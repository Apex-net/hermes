<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="d0ed9acb-0435-4532-afdd-b5115bc4d562" namespace="Apexnet.JobQueue.Configuration" xmlSchemaNamespace="urn:Apexnet.JobQueue.Configuration" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
    <externalType name="TimeSpan?" namespace="System" />
    <externalType name="Int32?" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="RedisStorage" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="redisStorage">
      <attributeProperties>
        <attributeProperty name="ConnectionString" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="connectionString" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="RedisStorageOptions" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="redisStorageOptions" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/RedisStorageOptions" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationSectionGroup name="HangfireStorage">
      <configurationSectionProperties>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/RedisStorage" />
          </containedConfigurationSection>
        </configurationSectionProperty>
        <configurationSectionProperty>
          <containedConfigurationSection>
            <configurationSectionMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/SqlServerStorage" />
          </containedConfigurationSection>
        </configurationSectionProperty>
      </configurationSectionProperties>
    </configurationSectionGroup>
    <configurationElement name="RedisStorageOptions">
      <attributeProperties>
        <attributeProperty name="Db" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="db" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/Int32?" />
          </type>
        </attributeProperty>
        <attributeProperty name="InvisibilityTimeout" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="invisibilityTimeout" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/TimeSpan?" />
          </type>
        </attributeProperty>
        <attributeProperty name="Prefix" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="prefix" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationSection name="SqlServerStorage" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="sqlServerStorage">
      <attributeProperties>
        <attributeProperty name="ConnectionString" isRequired="true" isKey="false" isDefaultCollection="false" xmlName="connectionString" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/d0ed9acb-0435-4532-afdd-b5115bc4d562/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationSection>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>