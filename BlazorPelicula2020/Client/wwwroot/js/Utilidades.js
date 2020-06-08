function pruebaPuntoNetStatic() {

    DotNet.invokeMethodAsync("BlazorPelicula2020.Client", "ObtenerCurrentCount").the(resultado =>
    {
        console.log("Conteo desde Javascript " + resultado);
    });

} 