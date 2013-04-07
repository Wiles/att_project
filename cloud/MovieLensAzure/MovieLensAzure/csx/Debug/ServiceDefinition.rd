<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="MovieLensAzure" generation="1" functional="0" release="0" Id="c7592c38-fa47-4915-b262-7cb602c44ad2" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="MovieLensAzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="MvcWebRole1:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/MovieLensAzure/MovieLensAzureGroup/LB:MvcWebRole1:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="MvcWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/MovieLensAzure/MovieLensAzureGroup/MapMvcWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="MvcWebRole1Instances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/MovieLensAzure/MovieLensAzureGroup/MapMvcWebRole1Instances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:MvcWebRole1:Endpoint1">
          <toPorts>
            <inPortMoniker name="/MovieLensAzure/MovieLensAzureGroup/MvcWebRole1/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapMvcWebRole1:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/MovieLensAzure/MovieLensAzureGroup/MvcWebRole1/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapMvcWebRole1Instances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/MovieLensAzure/MovieLensAzureGroup/MvcWebRole1Instances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="MvcWebRole1" generation="1" functional="0" release="0" software="D:\school\ATT\att_project\cloud\MovieLensAzure\MovieLensAzure\csx\Debug\roles\MvcWebRole1" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;MvcWebRole1&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;MvcWebRole1&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/MovieLensAzure/MovieLensAzureGroup/MvcWebRole1Instances" />
            <sCSPolicyUpdateDomainMoniker name="/MovieLensAzure/MovieLensAzureGroup/MvcWebRole1UpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/MovieLensAzure/MovieLensAzureGroup/MvcWebRole1FaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="MvcWebRole1UpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="MvcWebRole1FaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="MvcWebRole1Instances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="88c023ed-74ba-4e9e-9655-8744186908ab" ref="Microsoft.RedDog.Contract\ServiceContract\MovieLensAzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="a8950ef9-ac80-4122-9732-89ceadc1c43c" ref="Microsoft.RedDog.Contract\Interface\MvcWebRole1:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/MovieLensAzure/MovieLensAzureGroup/MvcWebRole1:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>