using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic; 
namespace Finalproject.Models

{
    public class DAO
    {
        public static MySqlConnection getconnectionDAO()
        {
            try{
                string query=@"server=localhost;userid=ayoub;password=ayoub hero;database=Books";
                MySqlConnection con=new MySqlConnection(query);
                Console.WriteLine("its worked");
                con.Open();
                return con;
            }catch(Exception e){
                Console.WriteLine(" Error: "+e.Message);
                return null;
            }
        }
        public static void adduser(Client client)
        {
            string query="insert into client(first_name,last_name,phone,email,password) values(@first_name,@last_name,@phone,@email,@password)";
            MySqlConnection con=DAO.getconnectionDAO();
            MySqlCommand cmd=new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@first_name",client.prenom);
            cmd.Parameters.AddWithValue("@last_name",client.nom);
            cmd.Parameters.AddWithValue("@phone",client.phone);
            cmd.Parameters.AddWithValue("@email",client.email);
            cmd.Parameters.AddWithValue("@password",client.password);
            cmd.ExecuteNonQuery();
            Console.WriteLine("its worked");
            con.Close();
        }
      
        public static void addlivre(Livre livre)
        {
             string query="insert into Livre(nom,nbrpage,langue,prix,autheur,annee,path,nomcatalogue) values(@nom,@nbrpage,@langue,@prix,@autheur,@annee,@path,@nomcatalogue)";
            MySqlConnection con=DAO.getconnectionDAO();
            MySqlCommand cmd=new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@nom",livre.Nom);
            cmd.Parameters.AddWithValue("@nbrpage",livre.nbrpage);
            cmd.Parameters.AddWithValue("@langue",livre.langue);
            cmd.Parameters.AddWithValue("@prix",livre.prix);
            cmd.Parameters.AddWithValue("@autheur",livre.autor);
            cmd.Parameters.AddWithValue("@annee",livre.anne);
            cmd.Parameters.AddWithValue("@path",livre.path);
            cmd.Parameters.AddWithValue("@nomcatalogue",livre.nomcatalogue);
            cmd.ExecuteNonQuery();
            Console.WriteLine("its worked");
            con.Close();
        }

        // public static void addcommande(Commande commande)
        // {
        //     string query="insert into command(email,nomlivre,q) values(@email,@nomlivre,@q)";
        //     MySqlConnection con=DAO.getconnectionDAO();
        //     MySqlCommand cmd=new MySqlCommand(query,con);
        //     cmd.Parameters.AddWithValue("@email",commande.emailclient);
        //     cmd.Parameters.AddWithValue("@nomlivre",commande.nomlivre);
        //     cmd.Parameters.AddWithValue("@q",commande.quntite);
        //     cmd.ExecuteNonQuery();
        //     Console.WriteLine("its worked");
        //     con.Close();
        // }

        public static void addCommande(string email,string nomlivre)
        {
            string query="insert into commande(email,nom) values(@email,@nom)";
            MySqlConnection con=DAO.getconnectionDAO();
            MySqlCommand cmd=new MySqlCommand(query,con);
            cmd.Parameters.AddWithValue("@email",email);
            cmd.Parameters.AddWithValue("@nom",nomlivre);
            cmd.ExecuteNonQuery();
            Console.WriteLine("its worked");
            con.Close();
        }

        public static List<Livre>  afficher(string type)
        {   
            string query="select * from Livre where nomcatalogue='"+type+"'";
            MySqlConnection connection=DAO.getconnectionDAO();
            MySqlCommand command=new MySqlCommand(query,connection);
            MySqlDataReader reader=command.ExecuteReader();
            List<Livre> livres = new List<Livre>();
            while(reader.Read())
            {
                Livre livre   = new Livre();
                livre.Id      =reader.GetInt32(0);
                livre.Nom     =reader.GetString(1);
                livre.nbrpage =reader.GetString(2);
                livre.langue  =reader.GetString(3);
                livre.prix    =reader.GetString(4);
                livre.autor   =reader.GetString(5);
                livre.anne    =reader.GetString(6);
                livre.path    =reader.GetString(7);
                livre.nomcatalogue =reader.GetString(8);
                livres.Add(livre);
            }
            return livres;
        }

        public static List<Commande> affichercommande()
        {
            string query="select * from commande";
            MySqlConnection connection=DAO.getconnectionDAO();
            MySqlCommand command=new MySqlCommand(query,connection);
            MySqlDataReader reader=command.ExecuteReader();
            List<Commande> commande = new List<Commande>();
            while(reader.Read())
            {
                Commande commande1=new Commande();
                commande1.ID=reader.GetInt32(0);
                commande1.emailclient=reader.GetString(1);
                commande1.nomlivre=reader.GetString(2);
                commande.Add(commande1);
            }
            return commande;
        }

        public static void Supprimertablecommande()
        {
            string query="TRUNCATE TABLE `commande`";
            MySqlConnection con=DAO.getconnectionDAO();
            MySqlCommand cmd=new MySqlCommand(query,con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("its worked");
            con.Close();
        }

        public static Livre afficherlivre(int id)
        {
            Livre livre = new Livre();
            string query="select * from Livre where id="+id+"";
            MySqlConnection connection=DAO.getconnectionDAO();
            MySqlCommand command=new MySqlCommand(query,connection);
            MySqlDataReader reader=command.ExecuteReader();
            if(reader.Read())
            {
                livre.Nom     =reader.GetString(1);
                livre.nbrpage =reader.GetString(2);
                livre.langue  =reader.GetString(3);
                livre.prix    =reader.GetString(4);
                livre.autor   =reader.GetString(5);
                livre.anne    =reader.GetString(6);
                livre.path    =reader.GetString(7);
                livre.nomcatalogue =reader.GetString(8);
            }
          
            return livre;
        }

         
        public static void supprimerlignecommande(int ID)
        {
            string query="delete from commande where id="+ID;
            MySqlConnection connection=DAO.getconnectionDAO();
            MySqlCommand command=new MySqlCommand(query,connection);
            command.ExecuteNonQuery();
            Console.WriteLine("its worked");
            connection.Close();
        }
        public static Client login(string email,string password)
        {
            Client client = new Client();
            // client=null;
            string query="select * from client where email='"+email+"' and password='"+password+"'";
            MySqlConnection con=DAO.getconnectionDAO();
            MySqlCommand command=new MySqlCommand(query,con);
            MySqlDataReader reader=command.ExecuteReader();
            if(reader.Read())
            {
                client.prenom     =reader.GetString(1);
                client.nom        =reader.GetString(2);
                client.phone      =reader.GetString(3);
                client.email      =reader.GetString(4);
                client.password   =reader.GetString(5);
                return client;
            }else{
                return null;
            }
            
        }

    }
}










            // cmd.Parameters.AddWithValue("@first_name",client.nom);
            // cmd.Parameters.AddWithValue("@last_name",client.prenom);
            // cmd.Parameters.AddWithValue("@phone",client.phone);
            // cmd.Parameters.AddWithValue("@email",client.email);
            // cmd.Parameters.AddWithValue("@password",client.password);