<?php
// Initialize the session
session_start();
 
// Check if the user is logged in, if not then redirect him to login page
if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
    header("location: index.php");
    exit;
}


// Include config file
require_once "./includes/config.php";
require_once "./models/Preference.php";

$dbArray = array();

$sql = "SELECT ID, Date, Available FROM Availability where EmployeeID = ?";
if($stmt = mysqli_prepare($link, $sql)){
  
    echo $_SESSION['id'];
    mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
    
    // Attempt to execute the prepared statement
    if(!mysqli_stmt_execute($stmt)){
      echo "Oops! Something went wrong. Please try again later.";
    }else{

            /* bind result variables */
          mysqli_stmt_bind_result($stmt, $id, $date, $available);

          /* fetch values */
          while (mysqli_stmt_fetch($stmt)) {
            echo $id . " " . $date . " " . $available . "<br";
            $pref = new Preference($id, $date, $_SESSION['id'], $available);
            array_push($dbArray, $pref);

          }
    }
    
    /* close statement */
    mysqli_stmt_close($stmt);
  }

 
$daysArray = array();

$date = new DateTime("now", new DateTimeZone('Europe/Amsterdam') );
$date = strtotime($date->format('Y-m-d H:i:s'));
for($i = 0; $i < 7; $i++){
  $pref = new Preference($i, strtotime("+$i day", $date), $_SESSION['id'], false);
  array_push($daysArray, $pref);
}


// Processing form data when form is submitted
if($_SERVER["REQUEST_METHOD"] == "POST"){

 $selected =  $daysArray[$_POST["the_clicked_id"]];
 $selected->set_Availability(true);

    
    // Prepare a select statement
    $sql = "INSERT INTO Availability(EmployeeID, Date, Available) values(?,?,?);";
    
    if($stmt = mysqli_prepare($link, $sql)){
      
        // Bind variables to the prepared statement as parameters
        $d = date('Y-m-d',$selected->get_Date());
        $a = $selected->get_Availability() ? 1 : 0;

        mysqli_stmt_bind_param($stmt, "sss", $_SESSION['id'], $d , $a);
        
        // Attempt to execute the prepared statement
        if(!mysqli_stmt_execute($stmt)){
          echo "Oops! Something went wrong. Please try again later.";
        }
      }
            // Close statement
            mysqli_stmt_close($stmt);
    
    // Close connection
    mysqli_close($link);

}


?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <!-- Google Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet">

    <!-- Bootstrap 4.0 CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <!-- Font Awesome Icons -->
    <script src="https://kit.fontawesome.com/03cf08f72f.js" crossorigin="anonymous"></script>

    <!-- JQuery 3.4.1 CDN -->
    <script src="https://code.jquery.com/jquery-3.4.1.js"  integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>


    <link rel="stylesheet" href="./css/header-page.css">
    <link rel="stylesheet" href="./css/preferences.css">

    <title>Preferences</title>
</head>
<body>
<!-- Navbar -->


<?php require('./shared/header.php') ?>




<div class="container preferences">

<form method="post">
<input id="the_clicked_id" type="hidden" name="the_clicked_id" value=""/>

<?php
    for ($i = 0; $i < count($daysArray); $i++) {

      ?>
    <div class="row">
      <div class="col-md-1"><span class="badge badge-info badge-pill">
        <?php echo date('d', $daysArray[$i]->get_Date());?>
      </div>
      <div class="col-md-1 ">
      <?php echo strtoupper(date('D', $daysArray[$i]->get_Date()));?>
      </div>
      <div class="col-md-8">
      <?php echo strtoupper($daysArray[$i]->get_Availability() ? "Available": "Not Available");?>
      </div>
      <div class="col-md-2">
      
      <?php
           echo "<button id=\"$i\" class=\"btn btn-outline-info\" name=\"submit_$i\" type=\"submit\"  onclick=\"return myId(this);\"><i class=\"fas fa-plus\"></i> </button>" . PHP_EOL;
      ?>

      </div>
    </div>

  
  
  <?php
    }
?>

</form>

</div>

<script>
myId = function (element) {
    document.getElementById('the_clicked_id').value = element.id;
    return true;
}
</script>


</body>
</html>