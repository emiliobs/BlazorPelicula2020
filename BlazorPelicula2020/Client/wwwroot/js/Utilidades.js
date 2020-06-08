function pruebaPuntoNetStatic() {

    DotNet.invokeMethodAsync("BlazorPelicula2020.Client", "ObtenerCurrentCount").then(resultado =>
    {
        console.log("Conteo desde Javascript " + resultado);
    });

} 

function prubaPuntoNETInstancia(dotnetHelper)
{
    dotnetHelper.invokeMethodAsync("IncrementCount");
}