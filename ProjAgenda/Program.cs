using ProjAgenda;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        string contactsFile = "contactsFile.txt";

        List<Contact> phoneBook = new();

        bool opc = false;

        do
        {
            switch (Menu())
            {
                case 1:
                    phoneBook.Add(CreateContact(phoneBook));
                    ContactsToFile(phoneBook, contactsFile);
                    phoneBook.Clear();
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine("Nome do contato a ser editado:");
                    break;
                case 3:
                    Console.WriteLine("Nome do contato a ser removido:");
                    break;
                case 4:
                    PrintPhoneBook(phoneBook);
                    break;
                case 5:
                    Console.WriteLine("Até mais :)");
                    break;

            }
        } while (!opc);

        int Menu()
        {
            Console.Write("\n\nMENU DE OÇÕES:" +
                                "\n1 - Inserir Contato" +
                                "\n2 - Editar Contato" +
                                "\n3 - Remover contato" +
                                "\n4 - Mostrar agenda" +
                                "\n5 - Sair " +
                                "\n\nEscolha uma opção:");
            int op = int.Parse(Console.ReadLine());
            return op;
        }
    }
    public static Contact CreateContact(List<Contact> l)
    {
        Console.WriteLine("Digite o nome:");
        string nome = Console.ReadLine();
        Console.WriteLine("Digite o telefone:");
        string phone = Console.ReadLine();
        Contact contatoNovo;

        if (l.Any())
        {
            foreach (var item in l)
            {
                if (item.Phone.Equals(phone))
                {
                    Console.WriteLine($"O Número de telefone já existe no contato {item.Name}");
                }
                else
                {
                    contatoNovo = new Contact(nome, phone);
                    return contatoNovo;
                }
            }

        }
        else
        {
            contatoNovo = new Contact(nome, phone);
            return contatoNovo;
        }

        return null;
    }

    public static void PrintPhoneBook(List<Contact> l)
    {
        if (!l.Any())
        {
            Console.WriteLine("A agenda está vazia!");
        }
        else
        {
             foreach (var item in l)
            {
                Console.WriteLine(item);
            }
        }
    }

    public static void ContactsToFile(List<Contact> l, string p)
    {
        try
        {
            if (File.Exists(p))
            {
                var txt = ReadFile(p);
                StreamWriter sw = new StreamWriter(p);
                sw.Write(txt);
                foreach (Contact item in l)
                {
                    sw.WriteLine(item.ToFile());
                }

                sw.Close();

            }
            else
            {
                StreamWriter sw = new(p);
                foreach (Contact item in l)
                {
                    sw.WriteLine(item.ToFile());
                }

                sw.Close();
            }

        }
        catch (Exception e)
        {
            StreamWriter sw = new(p);
            p = "error.log";
            sw = new(p);

            sw.WriteLine(e.Message.ToString());

            sw.Close();
        }

    }

    private static string ReadFile(string p)
    {
        {
            StreamReader sr = new(p);
            string text = "";
            try
            {
                text = sr.ReadToEnd();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sr.Close();
            }
            return text;
        }
    }



}




