<?php

// Starts a new session
session_start();

// Checks if the user is logged in, if not then redirect him to login page
if (!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true) {
  header("location: ../index.php");
  exit;
}

// Adds the database configuration
require_once "../includes/config.inc.php";

// Inlcudes Preferences Model
require_once "../models/Preference.php";


// Gets all preferences of the current user

$sql = "SELECT ID, UserID, State, Days, IsWeekly, IsMonthly FROM Availability Where UserID = ?";
$pref = null;
if ($stmt = mysqli_prepare($link, $sql)) {

  mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
  
  // Attempt to execute the prepared statement
  if (!mysqli_stmt_execute($stmt)) {
    echo "Oops! Something went wrong. Please try again later.";
  } else {

    /* bind result variables */
    $stmt->bind_result($id, $userID, $state, $days, $isWeekly, $isMonthly);

    /* fetch values */
    while ($stmt->fetch()) {
      // echo $id . " ". $userID . " " . $state . " " . $days .  " " . $isWeekly. " " . $isMonthly . "<br>"; 
       $pref = new Preference($id, $userID, $state, explode(",",$days), $isWeekly, $isMonthly);
    }
  }

  /* close statement */
  mysqli_stmt_close($stmt);
}

// Creating showable objects 
$daysArray = array();

// Generate 7 days from Monday
$date = new DateTime("Monday", new DateTimeZone('Europe/Amsterdam'));
$date = strtotime($date->format('D'));
for ($i = 0; $i < 7; $i++) {
  $d = strtotime("+$i day", $date);
  array_push($daysArray, date('D', $d));
}


function checkIfDateExists($date, $arr)
{
  for ($i = 0; $i < count($arr); $i++) {
    if ($arr[$i]->get_Date() == $date)
      return true;
  }
  return false;
}



$success_message = "";

// Processing form data when form is submitted
if ($_SERVER["REQUEST_METHOD"] == "POST") {

 $days = "";
 $monthly = $weekly = 0;
 if(isset($_POST['monthly'])) 
    $monthly = 1;

 if(isset($_POST['weekly'])) 
   $weekly = 1;

    for ($i=0; $i < 7; $i++) { 
      if(isset($_POST[$i])){
        
        $date = new DateTime("Monday", new DateTimeZone('Europe/Amsterdam'));
        $date = strtotime($date->format('D'));
        $d = strtotime("+$i day", $date);
        
          $days .= (date('D', $d) . ',');
      }
    }
    $days = substr($days, 0, -1);


    // Delete previous ticks of the user
    $sqlDelete = "DELETE FROM Availability WHERE UserID = ?";
    if ($stmt = mysqli_prepare($link, $sqlDelete)) {

      mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
      if (!mysqli_stmt_execute($stmt)) {
        echo "Oops! Something went wrong. Please try again later.";
      }
    }


        // Prepare a select statement
    $sql = "INSERT INTO Availability(UserID, Days, isWeekly, isMonthly) values(?,?,?,?);";

    if ($stmt = mysqli_prepare($link, $sql)) {

      // Bind variables to the prepared statement as parameters
      
      mysqli_stmt_bind_param($stmt, "ssss", $_SESSION['id'], $days, $weekly, $monthly);

      $success_message = "Success! Your preferences has been saved!";
      $pref = new Preference('', $_SESSION['id'], 'Pending', explode(",",$days), $weekly, $monthly);

      // Attempt to execute the prepared statement
      if (!mysqli_stmt_execute($stmt)) {
        echo "Oops! Something went wrong. Please try again later.";
        $success_message = "";
      }
      
    }
    // Closes the statement
    mysqli_stmt_close($stmt);

    // Closes the config DB connection
    mysqli_close($link);

}


?>

<!DOCTYPE html>
<html lang="en">

<head>

  <!-- Links -->
  <?php require './layouts/links.inc.php'; ?>

  <link rel="stylesheet" href="../resources/css/header-page.css">
  <link rel="stylesheet" href="../resources/css/preferences.css">

  <title>Preferences</title>
</head>

<body>

  <!-- Navbar -->
  <?php require('header.php') ?>

  <div class="container preferences">

    <h3></h3>
    <span class="success"><?php echo $success_message; ?></span>

    <h3> Choose your desired days to work:</h3>
    <form method="post">
      <div class="pick-group" id="group_id">

        <?php for ($i = 0; $i < count($daysArray); $i++) { ?>

          <div 
          
            <?php 
              echo "id=\"$i\""; 
            
              if($pref != null){
                if(in_array($daysArray[$i] ,$pref->Days))
                  echo "class=\"box selected\"";
                  else  echo "class=\"box\"";
              }else  echo "class=\"box\"";
            
          ?> >
            <div class="title">
              <span><?php echo $daysArray[$i]; ?></span>
            </div>

            <?php 
            if($pref != null){
              if(in_array($daysArray[$i] ,$pref->Days))
                echo '<input id="'. $daysArray[$i] .'"  type="hidden" name="' . $i .'" value="" />';
            }
            ?>
          </div>

        <?php } ?>
      </div>

      <h3> Repeating: </h3>

      <div class="pick-group-switch">
        <div class="switch-group">
          <div class="switch">
            <input id="switch-1" type="checkbox" name="monthly" class="switch-input" <?php  if($pref != null)if($pref->IsMonthly != null)  echo "checked";  ?> />
            <label for="switch-1" class="switch-label">Switch</label>
          </div>
            Monthly
        </div>

        <div class="switch-group">
          <div class="switch">
            <input id="switch-2" type="checkbox" name="weekly" class="switch-input2"  <?php if($pref != null)if($pref->IsWeekly != null)  echo "checked"; ?> />
            <label for="switch-2" class="switch-label2">Switch</label>
          </div>
            Weekly
        </div>
    
      </div>
    
      <h3></h3>
      <button  class="btn submit-btn"  type="submit"> Save your choice</button>
      
    </form>




    <!-- Chosing clickable event -->
    <script>
      var children = document.getElementById('group_id').childNodes;
      children.forEach(element => {
        if (element.id != undefined) {

          element.addEventListener('click', function() {
          
            $(element).toggleClass("selected");
            
            let $content;
            let day = element.childNodes[1].childNodes[1].textContent;   
            if(element.className == 'box selected'){
              let newElement=' <input id="'+ day +'"  type="hidden" name="' + element.id +'" value="" />';
              $content =  $(newElement).appendTo(element);

            }else{
              document.getElementById(day).remove();
            }
          });
        }
      });

    </script>

  </div>

</body>

</html>