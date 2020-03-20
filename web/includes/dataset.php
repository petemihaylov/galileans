<?php
header('Content-Type: application/json');

// Initialize the session
session_start();
 
// Check if the user is logged in, if not then redirect him to login page
if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
    header("location: index.php");
    exit;
}



require_once "./config.php";
require_once "../models/Shift.php";

$shiftArray = array();
// Get count of attended shifts for the current employee
$sql = "SELECT ID, ShiftDate, Attended FROM Shifts WHERE AssignedEmployeeID = ?";

if($stmt = mysqli_prepare($link, $sql)){
    
    mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
    
    // Attempt to execute the prepared statement
    if(mysqli_stmt_execute($stmt)){
        
        // Store result
        mysqli_stmt_store_result($stmt);
            
        $rows = mysqli_stmt_num_rows($stmt);

        for ($i=0; $i < $rows; $i++) { 
               
                mysqli_stmt_bind_result($stmt, $id, $shiftDate, $Attended);
                
                if(mysqli_stmt_fetch($stmt)){
                        $shift = new Shift($id, $shiftDate, "","","");
                        array_push($shiftArray, $shift);
          
                }
            }
    }else{
        echo "Oops! Something went wrong. Please try again later.";
    }
        // Close statement
        mysqli_stmt_close($stmt);
}

function countShiftsForDate($shiftArray, $date){
    $count = 0;
    foreach($shiftArray as $s){
        if($s->get_ShiftDate() == $date)$count++;
    }
    return $count;
}

function getUniqueDates($shiftArray){
    $uniqueDates = array();

    foreach($shiftArray as $s){
        if(!in_array($s->get_ShiftDate(), $uniqueDates)){
            $uniqueDates[] = $s->get_ShiftDate();
        }
    }
    return $uniqueDates;
}

$data = array();
$uniqueDatesShifts = getUniqueDates($shiftArray);

foreach ($uniqueDatesShifts as $d) {

    $count = countShiftsForDate($shiftArray,$d);
    
    $time = strtotime($d);

    $row = array(date('d M',$time), $count);

    array_push($data, $row);
}

   // Close connection
   mysqli_close($link);


   //get result
   echo json_encode($data);

?>