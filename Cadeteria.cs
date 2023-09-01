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

    public Cadeteria(string nombre, double telefono){
        this.nombre = nombre;
        this.telefono = telefono;
    }
    public void cargarCadetes(string archivo){
        List<Cadete> cadetes = new List<Cadete>();
        var cadetesCargados = File.ReadAllLines(archivo)
        .Skip(1).                           //Saltea el encabezado
        Select(line => line.Split(',')).
        Select(parts => new Cadete(int.Parse(parts[0]), parts[1], parts[2], long.Parse(parts[3])));
        cadetes.AddRange(cadetesCargados);
        ListaDeCadetes = cadetes;
        Console.WriteLine("Cadetes cargados correctamente");
    }
    public void mostrarDatosCadetes(){
        foreach(Cadete cadete in listaDeCadetes){
            cadete.MostrarDatosCadete();
        }
    }
    public void AsignarPedidoACadete(int numero , int id){
        foreach (var cadete in listaDeCadetes)
        {   
            if (cadete.Id==id){
                cadete.ListadoDePedidos.Add(listaPedidosCadeteria[numero-1]);
                Console.WriteLine("Asignado pedido: " + numero + " al cadete id: " + id);
            }
        }
    }
    public void RemoverPedidoCadeteria(int numero){
    listaPedidosCadeteria.RemoveAt(numero-1);
    RemoverPedidoCadete(numero);
    }
    public void ReasignarPedido(int numero, int id){
        foreach (var pedido in listaPedidosCadeteria)
        {
            if (pedido.Nro==numero)
            {
                RemoverPedidoCadete(numero);
                AsignarPedidoACadete(numero, id);
            }
        }
    }
    public void RemoverPedidoCadete(int numero){
        foreach (var cadete in listaDeCadetes)
        {
            cadete.RemoverPedido(numero);
        }
    }
    public void mostrarDatosClientes(){
        foreach (var pedido in ListaPedidosCadeteria) 
        {
            pedido.VerDatosCliente();
            pedido.VerDireccionCliente();
        }
    }
    /*public void AgregarCadete(int id, string nombreCadete, string direccion, double telefonoCadete){
        Cadete nuevo;
        nuevo = new Cadete(id,nombreCadete,direccion,telefonoCadete);
        listaDeCadetes.Add(nuevo);
    }*/
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
    public void mostrarPedidosCadeteria(){
        foreach (var pedido in listaPedidosCadeteria){
            Console.WriteLine("Numero: " + pedido.Nro);
            Console.WriteLine("Observacion: " + pedido.Obs);
            Console.WriteLine("Estado: " + pedido.Estado);
            pedido.VerDatosCliente();
            pedido.VerDireccionCliente();
        }
    }
    public void mostrarPedidosDeCadeteID(int id){
        foreach (var cadete in listaDeCadetes)
        {
            if (cadete.Id==id)
            {
                cadete.MostrarPedidosDelCadete();
            }
        }
    }

    public void CambiarEstadoDePedido(int numero, int opcion){
        foreach (var cadete in listaDeCadetes)
        {
            cadete.CambiarEstadoPedido(numero, opcion);
        }
    }
}
