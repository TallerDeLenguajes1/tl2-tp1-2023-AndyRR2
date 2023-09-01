namespace EspacioCliente;
using System;

public class Cliente{
    private string? nombre;
    private string? direccion;
    private int telefono;
    private string? DatosReferenciaDireccion;

    public string? Nombre { get => nombre; set => nombre = value; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public int Telefono { get => telefono; set => telefono = value; }
    public string? DatosReferenciaDireccion1 { get => DatosReferenciaDireccion; set => DatosReferenciaDireccion = value; }
}
