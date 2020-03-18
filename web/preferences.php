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

// Getting all of the user's preferences
$dbArray = array();

$sql = "SELECT ID, Date, Available FROM Availability where EmployeeID = ?";
if($stmt = mysqli_prepare($link, $sql)){
  
    mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
    
    // Attempt to execute the prepared statement
    if(!mysqli_stmt_execute($stmt)){
      echo "Oops! Something went wrong. Please try again later.";
    }else{
          
            /* bind result variables */
          $stmt->bind_result($id, $date, $available);

          /* fetch values */
          while ($stmt->fetch()) {
            # echo $id . " " . $date . " " . $available . "<br>";
            $pref = new Preference($id, $date, $_SESSION['id'], $available);
            array_push($dbArray, $pref);
          }
    }
    
    /* close statement */
    mysqli_stmt_close($stmt);
  }

 




// Creating showable objects 
$daysArray = array();

function checkIfDateExists($date, $arr){
  for($i = 0; $i < count($arr); $i++){
    if($arr[$i]->get_Date() == $date)
    return true;
  }
  return false;
}
$date = new DateTime("now", new DateTimeZone('Europe/Amsterdam') );
$date = strtotime($date->format('Y-m-d H:i:s'));
for($i = 0; $i < 7; $i++){
  $d = strtotime("+$i day", $date);
  if(checkIfDateExists(date('Y-m-d',$d),$dbArray))
  {
    $pref = new Preference($i, $d, $_SESSION['id'], true);
  }else{
    $pref = new Preference($i, $d, $_SESSION['id'], false);
  }
  array_push($daysArray, $pref);

}


// Processing form data when form is submitted
if($_SERVER["REQUEST_METHOD"] == "POST"){

 $selected =  $daysArray[$_POST["the_clicked_id"]];

 $dayTime = date('Y-m-d',$selected->get_Date());  
 if(checkIfDateExists($dayTime, $dbArray)){
  $sqlDelete = "DELETE FROM Availability WHERE Date = ?";
  if($stmt = mysqli_prepare($link, $sqlDelete)){
    
    mysqli_stmt_bind_param($stmt, "s", $dayTime);
    if(!mysqli_stmt_execute($stmt)){
      echo "Oops! Something went wrong. Please try again later.";
    }
  }
  $selected->set_Availability(false);  
}else{

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
        if($daysArray[$i]->get_Availability()){
          $daysArray[$i]->set_Booked(true);
        }else $daysArray[$i]->set_Booked(false);
      ?>
    <div class="row <?php echo $daysArray[$i]->get_Booked() ? "booked": ""; ?>">
      <div class="col-md-1">
        <div class="dayNumber <?php echo $daysArray[$i]->get_Booked() ? "booked-date": ""; ?>">
        <?php echo date('d', $daysArray[$i]->get_Date());?>
        </div>
      </div>
      <div class="col-md-1 weekDay">
      <?php echo strtoupper(date('D', $daysArray[$i]->get_Date()));?>
      </div>
      <div class="col-md-8">
      <?php echo strtoupper($daysArray[$i]->get_Availability() ? "Booked": "Available");?>
      </div>
      <div class="col-md-2">
      
      <?php
           $str =  "<button id=\"$i\" class=\"btn btn-outline-info\" name=\"submit_$i\" type=\"submit\"  onclick=\"return myId(this);\">";
             $res = $daysArray[$i]->get_Booked() ? "<i class=\"fas fa-minus\"></i>": "<i class=\"fas fa-plus\"></i>";
             echo $str . $res. "</button>" . PHP_EOL;
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