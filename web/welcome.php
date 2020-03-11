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
require_once "./models/Shift.php";

$shiftArray = array();

 // Prepare a select statement
 $sql = "SELECT ID, ShiftDate, StartTime, EndTime FROM Shifts Where AssignedEmployeeID = ?";
    if($stmt = mysqli_prepare($link, $sql)){
    
        mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
        
        // Attempt to execute the prepared statement
        if(mysqli_stmt_execute($stmt)){
            // Store result
            mysqli_stmt_store_result($stmt);
            
            $rows = mysqli_stmt_num_rows($stmt);

            for ($i=0; $i < $rows; $i++) { 
                   
                    mysqli_stmt_bind_result($stmt, $ID, $ShiftDate, $StartTime, $EndTime);
                    
                    if(mysqli_stmt_fetch($stmt)){
                            $shift = new Shift($ID, $ShiftDate, $StartTime, $EndTime);
                            array_push($shiftArray, $shift);
                    }
                }

        }else{
            echo "Oops! Something went wrong. Please try again later.";
        }
        
            // Close statement
            mysqli_stmt_close($stmt);
    }
    
    // Close connection
    mysqli_close($link);
?>



<?php require('./shared/header.php') ?>

<!-- Body -->
<div class="container welcome-container">
    <table class="table table-hover table-dark">
    <thead>
        <tr>
        <th scope="col">#</th>
        <th scope="col">Shift Date</th>
        <th scope="col">Start Time</th>
        <th scope="col">End Time</th>
        </tr>
    </thead>

    <tbody>
    <?php for ($i=0; $i < count($shiftArray); $i++) { ?>
        <tr>
        <th scope="row"> <?php echo $shiftArray[$i]->get_ID();?> </th>
        <td> <?php echo $shiftArray[$i]->get_ShiftDate();?></td>
        <td> <?php echo $shiftArray[$i]->get_StartTime();?></td>
        <td> <?php echo $shiftArray[$i]->get_EndTime();?></td>
        </tr>    

    <?php  }?>
    </tbody>
    
    </table>
</div>
    
<!-- Footer -->
<?php require('./shared/footer.php') ?>