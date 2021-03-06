﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CentroMedico.Mvc.PacienteSvc {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PacienteSvc.IPaciente")]
    public interface IPaciente {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPaciente/ValidarLoginPaciente", ReplyAction="http://tempuri.org/IPaciente/ValidarLoginPacienteResponse")]
        bool ValidarLoginPaciente(CentroMedico.Datos.PacienteEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPaciente/ValidarLoginPaciente", ReplyAction="http://tempuri.org/IPaciente/ValidarLoginPacienteResponse")]
        System.Threading.Tasks.Task<bool> ValidarLoginPacienteAsync(CentroMedico.Datos.PacienteEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPaciente/InsertarPaciente", ReplyAction="http://tempuri.org/IPaciente/InsertarPacienteResponse")]
        bool InsertarPaciente(CentroMedico.Datos.PacienteEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPaciente/InsertarPaciente", ReplyAction="http://tempuri.org/IPaciente/InsertarPacienteResponse")]
        System.Threading.Tasks.Task<bool> InsertarPacienteAsync(CentroMedico.Datos.PacienteEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPaciente/ObtenerPaciente", ReplyAction="http://tempuri.org/IPaciente/ObtenerPacienteResponse")]
        string ObtenerPaciente();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPaciente/ObtenerPaciente", ReplyAction="http://tempuri.org/IPaciente/ObtenerPacienteResponse")]
        System.Threading.Tasks.Task<string> ObtenerPacienteAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPaciente/ValidaDuplicidadPaciente", ReplyAction="http://tempuri.org/IPaciente/ValidaDuplicidadPacienteResponse")]
        bool ValidaDuplicidadPaciente(CentroMedico.Datos.PacienteEnt entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPaciente/ValidaDuplicidadPaciente", ReplyAction="http://tempuri.org/IPaciente/ValidaDuplicidadPacienteResponse")]
        System.Threading.Tasks.Task<bool> ValidaDuplicidadPacienteAsync(CentroMedico.Datos.PacienteEnt entidad);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPacienteChannel : CentroMedico.Mvc.PacienteSvc.IPaciente, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PacienteClient : System.ServiceModel.ClientBase<CentroMedico.Mvc.PacienteSvc.IPaciente>, CentroMedico.Mvc.PacienteSvc.IPaciente {
        
        public PacienteClient() {
        }
        
        public PacienteClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PacienteClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PacienteClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PacienteClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ValidarLoginPaciente(CentroMedico.Datos.PacienteEnt entidad) {
            return base.Channel.ValidarLoginPaciente(entidad);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarLoginPacienteAsync(CentroMedico.Datos.PacienteEnt entidad) {
            return base.Channel.ValidarLoginPacienteAsync(entidad);
        }
        
        public bool InsertarPaciente(CentroMedico.Datos.PacienteEnt entidad) {
            return base.Channel.InsertarPaciente(entidad);
        }
        
        public System.Threading.Tasks.Task<bool> InsertarPacienteAsync(CentroMedico.Datos.PacienteEnt entidad) {
            return base.Channel.InsertarPacienteAsync(entidad);
        }
        
        public string ObtenerPaciente() {
            return base.Channel.ObtenerPaciente();
        }
        
        public System.Threading.Tasks.Task<string> ObtenerPacienteAsync() {
            return base.Channel.ObtenerPacienteAsync();
        }
        
        public bool ValidaDuplicidadPaciente(CentroMedico.Datos.PacienteEnt entidad) {
            return base.Channel.ValidaDuplicidadPaciente(entidad);
        }
        
        public System.Threading.Tasks.Task<bool> ValidaDuplicidadPacienteAsync(CentroMedico.Datos.PacienteEnt entidad) {
            return base.Channel.ValidaDuplicidadPacienteAsync(entidad);
        }
    }
}
