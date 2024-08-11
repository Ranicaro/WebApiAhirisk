namespace WebApiAhirisk.Models.Administrativo
{
    public class mTipoProcesoRiesgo
    {
       
    }

    public class mProcesoRiesgo
    {
        public int? iIDTipoProceso { get; set; }
        public int? iIDTipoProcesosPaisIdioma { get; set; }
        public int? iIDProceso { get; set; }
        public int? iIDProcesoPaisIdioma { get; set; }
        public string? tDescripcionProceso { get; set; }
    }

    public class mMetodologiaRiesgo
    {
        public int? iIDMetodologiaRiesgo { get; set; }
        public int? iIDMetodologiaRiesgoPaisIdioma { get; set; }
        public string? tSigla { get; set; }
        public string? tDescripcion { get; set; }
    }

    public class mFactorRiesgo
    {
        public int? iIDMetodologiaRiesgo { get; set; }
        public int? iIDFactorRiesgo { get; set; }
        public int? iIDFactorRiesgoPaisIdioma { get; set; }
        public string? tDescripcionFactor { get; set; }
    }

    public class mOrganismoControl
    {
        public int? iIDEntidadOrganismoControl { get; set; }
        public int? iIDOrganismoControl { get; set; }
        public int? iIDPais { get; set; }
        public string? tSiglaOrganismo { get; set; }
        public string? tNombreOrganismo { get; set; }
    }

    public class mProductoRiesgo
    {
        public int? iIDOrganismoControl { get; set; }
        public int? iIDProducto { get; set; }
        public string? tCodigoProducto { get; set; }
        public string? tNombreProducto { get; set; }
    }
}
