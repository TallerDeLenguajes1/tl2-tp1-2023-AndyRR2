namespace EspacioCadete;
using System;
using System.ComponentModel;
using EspacioPedido;

public class Cadete{

    private int id;
    private string? nombre;
    private string? direccion;
    private double telefono;
    private List<Pedido>? listadoDePedidos = new List<Pedido>();

    public int Id { get => id; set => id = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public double Telefono { get => telefono; set => telefono = value; }
    public List<Pedido>? ListadoDePedidos { get => listadoDePedidos; set => listadoDePedidos = value; }

    public Cadete(int id, string nombre, string direccion, double telefono){
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this. telefono = telefono;
    }
    public void MostrarDatosCadete(){
        Console.WriteLine("Datos Cadete: ");
        Console.WriteLine("Id: " + id);
        Console.WriteLine("Nombre: " + nombre);
        Console.WriteLine("Direccion: " + direccion);
        Console.WriteLine("Telefono: " + telefono);
    }
    public void MostrarDatosCliente(){
        foreach (var pedido in listadoDePedidos)
        {
            pedido.VerDatosCliente();
            pedido.VerDireccionCliente();    
        }
    }
    public void MostrarPedidosDelCadete(){
        foreach (var pedido in listadoDePedidos)
        {
            Console.WriteLine("Numero: " + pedido.Nro);
            Console.WriteLine("Observacion: " + pedido.Obs);
            Console.WriteLine("Estado: " + pedido.Estado);
            MostrarDatosCliente();
        }
    }
    public void CambiarEstadoPedido(int numero,int opcion){
        foreach (var pedido in listadoDePedidos)
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
    public void RemoverPedido(int numero){
        foreach (var pedido in listadoDePedidos)
        {
            if (pedido.Nro==numero)
            {
                listadoDePedidos.Remove(pedido);break;
            }
        }
    }
    
}