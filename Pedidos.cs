namespace EspacioPedidos;
using System;
using EspacioCliente;

public class Pedidos{
    private int Nro;
    private string? Obs;
    private string? estado;

    public int Nro1 { get => Nro; set => Nro = value; }
    public string? Obs1 { get => Obs; set => Obs = value; }
    public string? Estado { get => estado; set => estado = value; }
    //private Cliente? cliente;????

    /*public void VerDireccionCliente(){

    }
    public void VerDatosCliente(){

    }*/
}