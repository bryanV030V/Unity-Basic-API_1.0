<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "newdtatbase";

$response = new mysqli();

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn-> connect_error)
{
  die("Connection Faild: " . $conn->connect_error);
}

$request = json_decode($_POST['request']);

switch ($request->action) {
  case "CreateAccount":
  $response->status = "OK";
  echo(json_encode($response));
    break;
  case "Login":
    break;
}


?>
