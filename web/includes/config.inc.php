<?php

define('DB_SERVER', 'remotemysql.com');
define('DB_USERNAME', 'Crj2OTSNvh');
define('DB_PASSWORD', '3bNXrfEhiw');
define('DB_NAME', 'Crj2OTSNvh');
 
/* Attempt to connect to MySQL database */
$link = mysqli_connect(DB_SERVER, DB_USERNAME, DB_PASSWORD, DB_NAME);
 
// Check connection
if($link === false){
    header("Location: error.php");
    die();
}
?>