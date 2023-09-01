namespace EspacioCadete;
using System;
using EspacioPedidos;

public class Cadete{

    private int id;
    private string? nombre;
    private string? direccion;
    private int telefono;

    public int Id { get => id; set => id = value; }
    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    //private List<Pedidos> listadoDePedidos;????

    /*public float JornalACobrar(){
        float cobra=0;

        return(cobra);
    }*/
}