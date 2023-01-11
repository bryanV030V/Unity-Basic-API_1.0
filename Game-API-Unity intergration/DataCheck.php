<?php
$response = new stdClass();
require_once("Database.php");

$email = "EMAILUSER";
$username = "NAMEUSER";

// we decoden de json en halen daar de email uit en zetten die in $email
$sql = "SELECT Email FROM users WHERE Email = '$email'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
  $response->status = "email_exists";
  echo("EMAIL ALREADY EXISTS!!");
} else {
  echo("EMAIL DOES NOT EXIST");
}


// hier check ik of de username bestaat
$sql = "SELECT Username FROM users WHERE Username = '$username'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
  $response->status = "email_exists";
  echo("USERNAME ALREADY EXISTS!!");
} else {
  // ga verder met het aanmaken van een account, dus een INSERT
  echo("USERNAME DOES NOT EXIST");
}
