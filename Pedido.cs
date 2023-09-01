namespace EspacioPedido;
using System;
using EspacioCliente;

public class Pedido{
    private int nro;
    private string? obs;
    private string? estado;
    private Cliente? cliente;

    public int Nro { get => nro; set => nro = value; }
    public string? Obs { get => obs; set => obs = value; }
    public Cliente? Cliente { get => cliente; set => cliente = value; }
    public string? Estado { get => estado; set => estado = value; }

    //se crea el pedido luego de crear el cliente
    public Pedido(int nro, string obs, string nombreCliente, string direccion, double telefono, string referencia){
        cliente = new Cliente(nombreCliente,direccion,telefono,referencia);
        this.nro = nro;
        this.obs = obs;
        this.estado = "Pendiente";
    }
    public void VerDireccionCliente(){
        Console.WriteLine("Direccion: " + cliente.Direccion);
    }
    public void VerDatosCliente(){
        Console.WriteLine("Nombre: " + cliente.Nombre);
        Console.WriteLine("Telefono: " + cliente.Telefono);
        Console.WriteLine("Referencia: " + cliente.DatosReferenciaDireccion);
    }

}