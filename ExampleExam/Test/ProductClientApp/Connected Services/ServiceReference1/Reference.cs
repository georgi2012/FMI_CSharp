﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductClientApp.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IOrderWService")]
    public interface IOrderWService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderWService/Retrieve", ReplyAction="http://tempuri.org/IOrderWService/RetrieveResponse")]
        TradeSerives.Product[] Retrieve();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderWService/Retrieve", ReplyAction="http://tempuri.org/IOrderWService/RetrieveResponse")]
        System.Threading.Tasks.Task<TradeSerives.Product[]> RetrieveAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderWService/Update", ReplyAction="http://tempuri.org/IOrderWService/UpdateResponse")]
        void Update(string sender, string productID, int qty);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderWService/Update", ReplyAction="http://tempuri.org/IOrderWService/UpdateResponse")]
        System.Threading.Tasks.Task UpdateAsync(string sender, string productID, int qty);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderWServiceChannel : ProductClientApp.ServiceReference1.IOrderWService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderWServiceClient : System.ServiceModel.ClientBase<ProductClientApp.ServiceReference1.IOrderWService>, ProductClientApp.ServiceReference1.IOrderWService {
        
        public OrderWServiceClient() {
        }
        
        public OrderWServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrderWServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderWServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderWServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TradeSerives.Product[] Retrieve() {
            return base.Channel.Retrieve();
        }
        
        public System.Threading.Tasks.Task<TradeSerives.Product[]> RetrieveAsync() {
            return base.Channel.RetrieveAsync();
        }
        
        public void Update(string sender, string productID, int qty) {
            base.Channel.Update(sender, productID, qty);
        }
        
        public System.Threading.Tasks.Task UpdateAsync(string sender, string productID, int qty) {
            return base.Channel.UpdateAsync(sender, productID, qty);
        }
    }
}
