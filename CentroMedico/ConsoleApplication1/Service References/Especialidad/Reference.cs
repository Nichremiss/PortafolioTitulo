﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1.Especialidad {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EspecialidadEnt", Namespace="http://schemas.datacontract.org/2004/07/CentroMedico.Datos")]
    [System.SerializableAttribute()]
    public partial class EspecialidadEnt : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string especialidad_descField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string especialidad_idField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string especialidad_desc {
            get {
                return this.especialidad_descField;
            }
            set {
                if ((object.ReferenceEquals(this.especialidad_descField, value) != true)) {
                    this.especialidad_descField = value;
                    this.RaisePropertyChanged("especialidad_desc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string especialidad_id {
            get {
                return this.especialidad_idField;
            }
            set {
                if ((object.ReferenceEquals(this.especialidad_idField, value) != true)) {
                    this.especialidad_idField = value;
                    this.RaisePropertyChanged("especialidad_id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Especialidad.IEspecialidad")]
    public interface IEspecialidad {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEspecialidad/InsertarEspecialidad", ReplyAction="http://tempuri.org/IEspecialidad/InsertarEspecialidadResponse")]
        bool InsertarEspecialidad(ConsoleApplication1.Especialidad.EspecialidadEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEspecialidad/InsertarEspecialidad", ReplyAction="http://tempuri.org/IEspecialidad/InsertarEspecialidadResponse")]
        System.Threading.Tasks.Task<bool> InsertarEspecialidadAsync(ConsoleApplication1.Especialidad.EspecialidadEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEspecialidad/ObtenerEspecialidad", ReplyAction="http://tempuri.org/IEspecialidad/ObtenerEspecialidadResponse")]
        string ObtenerEspecialidad();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEspecialidad/ObtenerEspecialidad", ReplyAction="http://tempuri.org/IEspecialidad/ObtenerEspecialidadResponse")]
        System.Threading.Tasks.Task<string> ObtenerEspecialidadAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEspecialidadChannel : ConsoleApplication1.Especialidad.IEspecialidad, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EspecialidadClient : System.ServiceModel.ClientBase<ConsoleApplication1.Especialidad.IEspecialidad>, ConsoleApplication1.Especialidad.IEspecialidad {
        
        public EspecialidadClient() {
        }
        
        public EspecialidadClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EspecialidadClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EspecialidadClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EspecialidadClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool InsertarEspecialidad(ConsoleApplication1.Especialidad.EspecialidadEnt entidad) {
            return base.Channel.InsertarEspecialidad(entidad);
        }
        
        public System.Threading.Tasks.Task<bool> InsertarEspecialidadAsync(ConsoleApplication1.Especialidad.EspecialidadEnt entidad) {
            return base.Channel.InsertarEspecialidadAsync(entidad);
        }
        
        public string ObtenerEspecialidad() {
            return base.Channel.ObtenerEspecialidad();
        }
        
        public System.Threading.Tasks.Task<string> ObtenerEspecialidadAsync() {
            return base.Channel.ObtenerEspecialidadAsync();
        }
    }
}
