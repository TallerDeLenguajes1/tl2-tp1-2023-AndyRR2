using System;
using EspacioCadeteria;
using EspacioPedido;

public class Program{
    
    private static void Main(){

      //Datos de la cadeteria
      double telefonoCadeteria = 326579254;
      string? nombreCadeteria = "Mensajes Cadeteria";
      Cadeteria cadeteria = new Cadeteria(nombreCadeteria , telefonoCadeteria);
      string? direccion = "Cadetes.csv"; 
      cadeteria.cargarCadetes(direccion);

      int opcion = 0;
      Console.WriteLine("Opciones:");
      Console.WriteLine("1-Dar de Alta pedido");
      Console.WriteLine("2-Asignar cadete a pedido");
      Console.WriteLine("3-Cambiar estado de pedido");
      Console.WriteLine("4-Reasignar cadete a otro pedido");
      Console.WriteLine("5-Mostrar pedidos de un cadete");
      Console.WriteLine("6-Mostrar datos de los cadetes de la cadeteria");
      Console.WriteLine("7-Mostrar datos y direccion de los clientes registrados");
      Console.WriteLine("8-Mostrar pedidos de la cadeteria");
      Console.WriteLine("9-Eliminar pedido");
      Console.WriteLine("0-Cerrar");
      string? entrada = Console.ReadLine();
      bool result = int.TryParse(entrada, out opcion);
      while (opcion!=0)
      {
        switch (opcion)
        {
          case 1: 
          cadeteria.DarDeAltaPedido();
          break;

          case 2: 
          int numero, id;
          Console.WriteLine("Entre numero del pedido a asignar: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out numero);
          Console.WriteLine("Entre el id del cadete: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out id);
          
          cadeteria.AsignarCadeteAPedido(id,numero);
          
          break;
          
          case 3:
          Console.WriteLine("Entre numero del pedido a modificar: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out numero);
          Console.WriteLine("1-Entregar, 2-Cancelar: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out opcion);
          cadeteria.CambiarEstadoPedido(numero,opcion);
          break;

          case 4:
          Console.WriteLine("Entre numero del pedido a reasignar: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out numero);
          Console.WriteLine("Entre el id del cadete: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out id);
          /*
          cadeteria.ReasignarPedido(numero, id);
          */
          break;

          case 5:
          Console.WriteLine("Entre el numero del pedido: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out numero);
          cadeteria.mostrarCadeteDePedido(numero);
          break;
          
          case 6: 
          cadeteria.mostrarDatosCadetes();
          break;
          
          case 7:
          cadeteria.mostrarDatosClientes();
          break;
          
          case 8:
          cadeteria.mostrarPedidosCadeteria();
          break;

          case 9:
          Console.WriteLine("Entre numero del pedido a eliminar: ");
          entrada = Console.ReadLine();
          result = int.TryParse(entrada, out numero);
          cadeteria.RemoverPedidoCadeteria(numero);
          break;
        }
        Console.WriteLine("Opciones:");
        Console.WriteLine("1-Dar de Alta pedido");
        Console.WriteLine("2-Asignar cadete a pedido");
        Console.WriteLine("3-Cambiar estado de pedido");
        Console.WriteLine("4-Reasignar cadete a otro pedido");
        Console.WriteLine("5-Mostrar cadete de un pedido");
        Console.WriteLine("6-Mostrar datos de los cadetes de la cadeteria");
        Console.WriteLine("7-Mostrar datos y direccion de los clientes registrados");
        Console.WriteLine("8-Mostrar pedidos de la cadeteria");
        Console.WriteLine("9-Eliminar pedido");
        Console.WriteLine("0-Cerrar");
        entrada = Console.ReadLine();
        result = int.TryParse(entrada, out opcion);
        
      }
      

      
    }

    
}
