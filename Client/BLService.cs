﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IBLService")]
public interface IBLService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBLService/GetPrices", ReplyAction="http://tempuri.org/IBLService/GetPricesResponse")]
    string GetPrices(string imageLoc);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBLService/GetPrices", ReplyAction="http://tempuri.org/IBLService/GetPricesResponse")]
    System.Threading.Tasks.Task<string> GetPricesAsync(string imageLoc);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IBLServiceChannel : IBLService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class BLServiceClient : System.ServiceModel.ClientBase<IBLService>, IBLService
{
    
    public BLServiceClient()
    {
    }
    
    public BLServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public BLServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public BLServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public BLServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public string GetPrices(string imageLoc)
    {
        return base.Channel.GetPrices(imageLoc);
    }
    
    public System.Threading.Tasks.Task<string> GetPricesAsync(string imageLoc)
    {
        return base.Channel.GetPricesAsync(imageLoc);
    }
}