using System;
using System.IO;
using System.Text;
using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading; //sleep = Thread.Sleep(2000);

class Acesso{
  public static void cadastro(){
    string nome;
    string email;
    string senha;

    Console.Clear();
    C.w("Digite seu nome: ");
    nome = C.r();
    C.w("Digite seu email: ");
    email = C.r();
    C.w("Digite sua senha: ");
    senha = C.r();

    var usuario = new Usuario(nome, email, senha);
    salvar(usuario);
    C.w(usuario.getNome());
  }

  public static void salvar (Usuario usuario){
    using (var mem = new MemoryStream())
    using (var writer = new StreamWriter(mem))
    using (var csvWriter = new CsvWriter(writer))
    {
      csvWriter.Configuration.Delimiter = ";";
      csvWriter.Configuration.HasHeaderRecord = true;
      csvWriter.Configuration.AutoMap<Usuario>();

      csvWriter.WriteHeader<Usuario>();
      csvWriter.WriteRecords(data);

      writer.Flush();
      var result = Encoding.UTF8.GetString(mem.ToArray());
      Console.WriteLine(result);
    }
  }
  public static bool entrar (string email, string senha){
    var usuarios = GetUsuarios();
    foreach (Array usuario in usuarios){
      if (usuario[1] == email && usuario[2] == senha){
        return true;
      }
    }
    C.W("")
    return false;
  }
  public static bool GetLogin(){
    string email;
    string senha;

    S.W("Digite seu mailBOX: ");
    email = W.R();
    S.W("Digite sua senha: ");
    senha = W.R();

    return entrar(email, senha);
  }

  public static  Contato (){
    var usuarios = GetUsuarios();
    bool flag2 = false;
    while (flag2 == false){
      C.W("Digite o email do destinaário: ")
      string amigo = C.R();
      if (usuarios.Contains(amigo) == false){
        C.W("Email do destinatário inválido.\nDigite novamente ou digite 3 para sair.")
        string resp = C.R();
        if(resp=="3") flag2 = true;
      }
      else{
        //FUNCAO PARA PEGAR ESTE Usuario.
        //FUNCAO PARA ENVIAR MENSAGEM PARA ESTE USUARIO.
              

              

            }
          }
  }
  
    
  }


}
