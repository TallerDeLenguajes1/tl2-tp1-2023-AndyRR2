namespace EspacioCadeteria;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using EspacioCadete;
using EspacioPedido;

public class Cadeteria{
    private string? nombre;
    private double telefono;
    
    private List<Pedido> listaPedidosCadeteria = new List<Pedido>(); 
    private List<Cadete>? listaDeCadetes;

    public string? Nombre { get => nombre; set => nombre = value; }
    public double Telefono { get => telefono; set => telefono = value; }
    public List<Cadete>? ListaDeCadetes { get => listaDeCadetes; set => listaDeCadetes = value; }
    public List<Pedido> ListaPedidosCadeteria { get => listaPedidosCadeteria; set => listaPedidosCadeteria = value; }

    //crea cadeteria
    public Cadeteria(string nombre, double telefono){
        this.nombre = nombre;
        this.telefono = telefono;
    }
    public void cargarCadetes(string archivo){
        List<Cadete> cadetes = new List<Cadete>();
        var cadetesCargados = File.ReadAllLines(archivo)
        .Skip(1).                           //Saltea el encabezado
        Select(line => line.Split(',')).
        Select(parts => new Cadete(int.Parse(parts[0]), parts[1], parts[2], double.Parse(parts[3])));
        cadetes.AddRange(cadetesCargados);
        ListaDeCadetes = cadetes;
        Console.WriteLine("Cadetes cargados correctamente");
    }
        public void DarDeAltaPedido(){
        int numero;
        string? obs, nombreCliente, direccion, referencia;
        double telefonoCliente;
        
        Console.WriteLine("Ingrese el numero de pedido");
        string? entrada = Console.ReadLine();
        bool result = int.TryParse(entrada, out numero);
        
        Console.WriteLine("Ingrese la observación del pedido");
        obs = Console.ReadLine();
        
        Console.WriteLine("Ingrese el nombre del cliente");
        nombreCliente = Console.ReadLine();
        
        Console.WriteLine("Ingrese la dirección del cliente");
        direccion = Console.ReadLine();
        
        Console.WriteLine("Ingrese el teléfono del cliente");
        entrada = Console.ReadLine();
        result = double.TryParse(entrada, out telefonoCliente);
        
        Console.WriteLine("Ingrese una referencia para la dirección");
        referencia = Console.ReadLine();
        Pedido pedido = new Pedido(numero, obs, nombreCliente, direccion, telefonoCliente, referencia);
        listaPedidosCadeteria.Add(pedido);
    }
    public void mostrarDatosCadetes(){
        foreach(Cadete cadete in listaDeCadetes){
            cadete.MostrarDatosCadete();
        }
    }
    public void mostrarPedidosCadeteria(){
    foreach (var pedido in listaPedidosCadeteria){
        Console.WriteLine("Numero: " + pedido.Nro);
        Console.WriteLine("Observacion: " + pedido.Obs);
        Console.WriteLine("Estado: " + pedido.Estado);
        Console.WriteLine("Precio: " + pedido.Precio);
        pedido.VerDatosCliente();
        pedido.VerDireccionCliente();
        }
    }
    public void mostrarDatosClientes(){
        foreach (var pedido in ListaPedidosCadeteria) 
        {
            pedido.VerDatosCliente();
            pedido.VerDireccionCliente();    
        }
    }
    public void CambiarEstadoPedido(int numero,int opcion){
        foreach (var pedido in listaPedidosCadeteria)
        {
            if (pedido.Nro==numero)
            {
                switch(opcion){
                    case 1:
                    pedido.Estado="Entregado";
                    break;
                    case 2:
                    pedido.Estado="Cancelado";
                    break;
                }
            }
        }
    }
    public void RemoverPedidoCadeteria(int numero){
        listaPedidosCadeteria.RemoveAt(numero-1);
    }
    public void AsignarCadeteAPedido(int id, int numero){
        foreach (var pedido in listaPedidosCadeteria)
        {
            if (pedido.Nro==numero)
            {
                foreach (var cadete in listaDeCadetes)
                {
                    if (cadete.Id==id)
                    {
                        pedido.Cadete=cadete;
                    }
                }
            }
        }
    }
    public void mostrarCadeteDePedido(int numero){
        foreach (var pedido in listaPedidosCadeteria)
        {
            if (pedido.Nro==numero)
            {
                pedido.MostrarCadete();
            }
        }
    }
    /*public void AsignarPedidoACadete(int numero , int id){
        foreach (var cadete in listaDeCadetes)
        {   
            if (cadete.Id==id){
                cadete.ListadoDePedidos.Add(listaPedidosCadeteria[numero-1]);
                Console.WriteLine("Asignado pedido: " + numero + " al cadete id: " + id);
            }
        }
    }*/
    /*public void mostrarPedidosDeCadeteID(int id){
        foreach (var cadete in listaDeCadetes)
        {
            if (cadete.Id==id)
            {
                cadete.MostrarPedidosDelCadete();
            }
        }
    }*/
    /*public void RemoverPedidoCadete(int numero){
        foreach (var cadete in listaDeCadetes)
        {
            cadete.RemoverPedido(numero);
        }
    }*/
    /*public void ReasignarPedido(int numero, int id){
        foreach (var pedido in listaPedidosCadeteria)
        {
            if (pedido.Nro==numero)
            {
                RemoverPedidoCadete(numero);
                AsignarPedidoACadete(numero, id);
            }
        }
    }*/
    /*public float JornalACobrar(int id){
        
        return(monto);
    }*/

    

    
}
