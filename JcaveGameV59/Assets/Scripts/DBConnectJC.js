import System;
import System.Data;
import System.Data.SqlClient;
import UnityEngine;



function Start () {
//    [INDENT]

    var dbcon : IDbConnection;
    var connectionString : String = "Server=bssjcave.database.windows.net;" + "Database=JCaveDB;" +"User ID=bss;" +"Password=B1S2S3.ssb;";

    dbcon = new SqlConnection(connectionString);
    dbcon.Open();

    if (dbcon!=null){
    	Debug.Log(">>>connected>>>>");
    	//var  quary: String = 
    	//dbcmd.CommandText = cmdSql;
    	  
    	// var dbcmd : IDbCommand = dbcon.CreateCommand();
    //string var, to save the command we want to use
/*var    query : String = "SELECT * FROM Player";
        dbcmd = dbcon.CreateCommand();

        dbcmd.CommandText = query; 
        reader = dbcmd.ExecuteReader();
        while(reader.Read()) {
        var id : String = reader ["PName"].ToString();
        var nome : String = reader ["PPassword"].ToString();
        var login : String = reader ["charcter"].ToString();
        var senha : String = reader ["arm"].ToString();
        print ("ID: " + id + "NAME: " + nome + "LOGIN: " + login + "PASSWORD: " + senha);
    }*/
    var    query : String = "INSERT INTO Player (PName,PPassword,charcter,arm)VALUES(SAFO,123,1,1)"  ;
        dbcmd = dbcon.CreateCommand();

        dbcmd.CommandText = query; 
    	}
    	else 
    	{
    	Debug.Log("notconnected");
    	}

    	dbcon.Close();
dbcon = null;

}

function Update () {
	
}
