using System;
using System.Collections.Generic;
using Backend;

namespace Frontend.Console;

public static class Program
{
    public static void Main(string[] args)
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        RunMenu();
    }

    private static void RunMenu()
    {
        // Using NaturalStringComparer so numeric strings ("10", "2", "3") sort numerically as [2, 3, 10]
        // while text strings ("Blanco", "Azul") sort lexicographically as [Azul, Blanco].
        var list = new DoublyLinkedList<string>(NaturalStringComparer.Default);

        bool running = true;
        while (running)
        {
            PrintHeader();
            System.Console.WriteLine("1. Adicionar.");
            System.Console.WriteLine("2. Mostrar hacia adelante.");
            System.Console.WriteLine("3. Mostrar hacia atrás.");
            System.Console.WriteLine("4. Ordenar descendentemente.");
            System.Console.WriteLine("5. Mostrar la(s) moda(s).");
            System.Console.WriteLine("6. Mostrar gráfico.");
            System.Console.WriteLine("7. Existe.");
            System.Console.WriteLine("8. Eliminar una ocurrencia.");
            System.Console.WriteLine("9. Eliminar todas las ocurrencias.");
            System.Console.WriteLine("P. Cargar preset de prueba (Colores, Números PDF o Prueba 10/2/3).");
            System.Console.WriteLine("C. Limpiar lista.");
            System.Console.WriteLine("0. Salir.");
            System.Console.WriteLine(new string('-', 50));
            System.Console.Write("Seleccione una opción: ");

            var option = System.Console.ReadLine()?.Trim().ToUpperInvariant();
            System.Console.WriteLine();

            switch (option)
            {
                case "1":
                    AddElement(list);
                    break;

                case "2":
                    ShowForward(list);
                    break;

                case "3":
                    ShowBackward(list);
                    break;

                case "4":
                    SortDescending(list);
                    break;

                case "5":
                    ShowModes(list);
                    break;

                case "6":
                    ShowChart(list);
                    break;

                case "7":
                    CheckExists(list);
                    break;

                case "8":
                    RemoveOneOccurrence(list);
                    break;

                case "9":
                    RemoveAllOccurrences(list);
                    break;

                case "P":
                    LoadPreset(list);
                    break;

                case "C":
                    list.Clear();
                    System.Console.WriteLine("Lista vaciada con éxito.");
                    break;

                case "0":
                    running = false;
                    System.Console.WriteLine("Saliendo del programa. ¡Hasta pronto!");
                    break;

                default:
                    System.Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

            if (running)
            {
                System.Console.WriteLine();
                System.Console.Write("Presione ENTER para continuar...");
                System.Console.ReadLine();
                System.Console.Clear();
            }
        }
    }

    private static void PrintHeader()
    {
        System.Console.WriteLine("==================================================");
        System.Console.WriteLine("          Taller #5 - Listas Ligadas              ");
        System.Console.WriteLine("      Estructura de Datos - ITM Medellín          ");
        System.Console.WriteLine(" (Ordenamiento natural: Números y Palabras OK)    ");
        System.Console.WriteLine("==================================================");
    }

    private static void AddElement(DoublyLinkedList<string> list)
    {
        System.Console.Write("Ingrese el elemento a adicionar: ");
        var input = System.Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(input))
        {
            System.Console.WriteLine("No se ingresó ningún elemento.");
            return;
        }

        list.Add(input);
        System.Console.WriteLine($"Elemento '{input}' adicionado exitosamente en orden.");
        System.Console.WriteLine($"Lista actual: {string.Join(", ", list.ToForwardList())}");
    }

    private static void ShowForward(DoublyLinkedList<string> list)
    {
        if (list.IsEmpty)
        {
            System.Console.WriteLine("La lista está vacía.");
            return;
        }

        var items = list.ToForwardList();
        System.Console.WriteLine("Recorrido hacia adelante:");
        System.Console.WriteLine(string.Join(", ", items));
    }

    private static void ShowBackward(DoublyLinkedList<string> list)
    {
        if (list.IsEmpty)
        {
            System.Console.WriteLine("La lista está vacía.");
            return;
        }

        var items = list.ToBackwardList();
        System.Console.WriteLine("Recorrido hacia atrás:");
        System.Console.WriteLine(string.Join(", ", items));
    }

    private static void SortDescending(DoublyLinkedList<string> list)
    {
        if (list.IsEmpty)
        {
            System.Console.WriteLine("La lista está vacía.");
            return;
        }

        list.SortDescending();
        System.Console.WriteLine("La lista ha sido ordenada descendentemente (operación idempotente).");
        System.Console.WriteLine($"Resultado: {string.Join(", ", list.ToForwardList())}");
    }

    private static void ShowModes(DoublyLinkedList<string> list)
    {
        if (list.IsEmpty)
        {
            System.Console.WriteLine("La lista está vacía. No hay moda.");
            return;
        }

        var (modes, maxFrequency) = list.GetModes();
        if (modes.Count == 1)
        {
            System.Console.WriteLine($"La moda es: {modes[0]} (ocurrencias: {maxFrequency})");
        }
        else
        {
            System.Console.WriteLine($"Las modas son: {string.Join(", ", modes)} (ocurrencias: {maxFrequency})");
        }
    }

    private static void ShowChart(DoublyLinkedList<string> list)
    {
        if (list.IsEmpty)
        {
            System.Console.WriteLine("La lista está vacía. No hay gráfico para mostrar.");
            return;
        }

        System.Console.WriteLine("Gráfico de ocurrencias:");
        System.Console.WriteLine(list.GetAsteriskChart());
    }

    private static void CheckExists(DoublyLinkedList<string> list)
    {
        System.Console.Write("Ingrese el elemento a buscar: ");
        var input = System.Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(input))
        {
            System.Console.WriteLine("No se ingresó ningún elemento.");
            return;
        }

        if (list.Exists(input))
        {
            System.Console.WriteLine($"El elemento '{input}' existe.");
        }
        else
        {
            System.Console.WriteLine($"No existe el {input}.");
        }
    }

    private static void RemoveOneOccurrence(DoublyLinkedList<string> list)
    {
        System.Console.Write("Ingrese el elemento para eliminar una ocurrencia: ");
        var input = System.Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(input))
        {
            System.Console.WriteLine("No se ingresó ningún elemento.");
            return;
        }

        bool removed = list.RemoveOne(input);
        if (removed)
        {
            System.Console.WriteLine($"Se eliminó la primera ocurrencia de '{input}'.");
            System.Console.WriteLine($"Lista actual: {(list.IsEmpty ? "(vacía)" : string.Join(", ", list.ToForwardList()))}");
        }
        else
        {
            System.Console.WriteLine($"El elemento '{input}' no se encontró en la lista.");
        }
    }

    private static void RemoveAllOccurrences(DoublyLinkedList<string> list)
    {
        System.Console.Write("Ingrese el elemento para eliminar todas sus ocurrencias: ");
        var input = System.Console.ReadLine()?.Trim();
        if (string.IsNullOrEmpty(input))
        {
            System.Console.WriteLine("No se ingresó ningún elemento.");
            return;
        }

        int count = list.RemoveAll(input);
        if (count > 0)
        {
            System.Console.WriteLine($"Se eliminaron {count} ocurrencia(s) de '{input}'.");
            System.Console.WriteLine($"Lista actual: {(list.IsEmpty ? "(vacía)" : string.Join(", ", list.ToForwardList()))}");
        }
        else
        {
            System.Console.WriteLine($"El elemento '{input}' no se encontró en la lista.");
        }
    }

    private static void LoadPreset(DoublyLinkedList<string> list)
    {
        System.Console.WriteLine("Seleccione preset a cargar:");
        System.Console.WriteLine("1. Colores del PDF: Blanco, Azul, Amarillo, Verde, Negro");
        System.Console.WriteLine("2. Números del PDF (Moda única): 1, 2, 3, 3, 2, 5, 6, 6, 6, 3, 6");
        System.Console.WriteLine("3. Números del PDF (Multimodal): 1, 2, 3, 3, 2, 5, 6, 6, 6, 3");
        System.Console.WriteLine("4. Prueba Números 10, 2, 3 (Verifica orden numérico: 2, 3, 10)");
        System.Console.Write("Opción: ");
        var choice = System.Console.ReadLine()?.Trim();

        list.Clear();
        switch (choice)
        {
            case "1":
                foreach (var item in new[] { "Blanco", "Azul", "Amarillo", "Verde", "Negro" })
                {
                    list.Add(item);
                }
                System.Console.WriteLine("Cargados colores del enunciado.");
                break;

            case "2":
                foreach (var item in new[] { "1", "2", "3", "3", "2", "5", "6", "6", "6", "3", "6" })
                {
                    list.Add(item);
                }
                System.Console.WriteLine("Cargada secuencia con moda 6.");
                break;

            case "3":
                foreach (var item in new[] { "1", "2", "3", "3", "2", "5", "6", "6", "6", "3" })
                {
                    list.Add(item);
                }
                System.Console.WriteLine("Cargada secuencia con modas 3, 6.");
                break;

            case "4":
                foreach (var item in new[] { "10", "2", "3" })
                {
                    list.Add(item);
                }
                System.Console.WriteLine("Cargados números 10, 2, 3 ordenados numéricamente.");
                break;

            default:
                System.Console.WriteLine("Preset no reconocido.");
                break;
        }

        System.Console.WriteLine($"Lista resultante: {string.Join(", ", list.ToForwardList())}");
    }
}
