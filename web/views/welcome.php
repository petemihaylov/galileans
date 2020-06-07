<?php
// Initialize the session
session_start();
 
// Check if the user is logged in, if not then redirect him to login page
if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
    header("location: ../index.php");
    exit;
}


// Include config file
require_once "../includes/config.inc.php";
require "../models/Shift.php";

// for the pdf
require_once  '../vendor/autoload.php';

function getPDF($arr){
    $data = "";
    $mpdf = new \Mpdf\Mpdf();
    $data .= '<h1>Shift details</h1>';

    $data .= "<table>
    <thead>
        <tr>
        <th>
        </th>
        <th>Type</th>
        <th> Date</th>
        <th>Start Time</th>
        <th>End Time</th>
        </tr>
    </thead> ";

    $data .="<tbody>";
    
    for ($i=0; $i < count($arr); $i++) { 
       $data .= " <tr><th> ";
       $data .= $i . " </th>
        <td> ".  $arr[$i]->get_ShiftType()."</td>
        <td> ". $arr[$i]->get_ShiftDate()."</td>
        <td>" . $arr[$i]->get_StartTime()."</td>
        <td>" . $arr[$i]->get_EndTime(). "</td>
        </tr> ";
    }
    $data .="</tbody></table>";

    $mpdf->WriteHTML($data);
    $mpdf->Output("my-shifts-details.pdf", "D");
}

$shiftArray = array();

 // Prepare a select statement
 $sql = "SELECT ID, ShiftDate, StartTime, EndTime, ShiftType FROM Shift Where AssignedUserID = ?";
    if($stmt = mysqli_prepare($link, $sql)){
    
        mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
        
        // Attempt to execute the prepared statement
        if(mysqli_stmt_execute($stmt)){
            // Store result
            mysqli_stmt_store_result($stmt);
            
            $rows = mysqli_stmt_num_rows($stmt);

            for ($i=0; $i < $rows; $i++) { 
                   
                    mysqli_stmt_bind_result($stmt, $ID, $ShiftDate, $StartTime, $EndTime, $ShiftType);
                    
                    if(mysqli_stmt_fetch($stmt)){
                            $shift = new Shift($ID, $ShiftDate, $StartTime, $EndTime, $ShiftType);
                            array_push($shiftArray, $shift);
                    }
                }

        }else{
            echo "Oops! Something went wrong. Please try again later.";
        }
        
    mysqli_stmt_close($stmt);
    }

// closestShift
$date = new DateTime("now", new DateTimeZone('Europe/Amsterdam') );
$shtDate = $date->format('Y-m-d');
$shStart = $date->format('H:i:s');


$closestShift;

 // Prepare a select statement
 $sql = "SELECT ID, ShiftDate, StartTime, EndTime, ShiftType
FROM Shift WHERE ShiftDate <= ? && StartTime <= ? && AssignedUserID = ? ORDER BY ShiftDate DESC, StartTime DESC limit 1";



   if($stmt = mysqli_prepare($link, $sql)){
    
    mysqli_stmt_bind_param($stmt, "sss", $shtDate, $shStart, $_SESSION['id']);
    // Attempt to execute the prepared statement
    if(mysqli_stmt_execute($stmt)){
        
        // Store result
        mysqli_stmt_store_result($stmt);
    
        
        $stmt->bind_result($Id, $shDate, $shStartTime, $shEndTime , $shType);
        

        if(mysqli_stmt_fetch($stmt)) {
            $closestShift = new Shift($Id, strval($shDate), strval($shStartTime), strval($shEndTime), $shType);
         }

    }else{
        echo "Oops! Something went wrong. Please try again later.";
    }
    
        // Close statement
        mysqli_stmt_close($stmt);
}
 
    // Close connection
    mysqli_close($link);

  // Processing form data when form is submitted
    if($_SERVER["REQUEST_METHOD"] == "POST"){
        getPDF($shiftArray);

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
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css">
    <!-- Font Awesome Icons -->
    <script src="https://kit.fontawesome.com/03cf08f72f.js" crossorigin="anonymous"></script>

    <!-- JQuery 3.4.1 CDN -->
    <script src="https://code.jquery.com/jquery-3.4.1.js"  integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>
  
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js"></script>
    
  

    
    <link rel="stylesheet" href="../resources/css/header-page.css">
    <link rel="stylesheet" href="../resources/css/welcome-page.css">
    
    <title>Welcome</title>
</head>
<body>
<!-- Navbar -->
<?php require('header.php') ?>


<div class="container next-shift">
    
  <?php if(isset($closestShift)){?>

  <p ><i class="fas fa-forward  faa-wrench animated"></i> Next shift:
     <?php 
        echo "<b>" . $closestShift->get_ShiftType() ."  ". $closestShift->get_ShiftDate()."</b>"; 
      ?>
 </p>

  <?php } ?>

</div>

<div class="container welcome-container">
    <table id="example" class="table table-hover table-dark">
    <thead>
        <tr>
        <th scope="col">
            <form class="btn-pdf" method="post">
                <button type="submit" class="btn btn-primary">PDF</button>
            </form>
        </th>
        <th scope="col">Type</th>
        <th scope="col"> Date</th>
        <th scope="col">Start Time</th>
        <th scope="col">End Time</th>
        </tr>
    </thead>

    <tbody>
    <?php for ($i=0; $i < count($shiftArray); $i++) { ?>
        <tr>
        
        <th scope="row"> <?php echo $i+1 ?> </th>
        <td> <?php echo $shiftArray[$i]->get_ShiftType();?></td>
        <td> <?php echo $shiftArray[$i]->get_ShiftDate();?></td>
        <td> <?php echo $shiftArray[$i]->get_StartTime();?></td>
        <td> <?php echo $shiftArray[$i]->get_EndTime();?></td>
        </tr>    

    <?php  }?>
    </tbody>
    
    </table>
        
</div>

<script>
$(document).ready(function() {
    $('#example').DataTable();
} );
</script>

<!-- Footer -->
<?php require('footer.php') ?>