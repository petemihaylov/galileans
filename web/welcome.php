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
require "./models/Shift.php";

$shiftArray = array();

 // Prepare a select statement
 $sql = "SELECT ID, ShiftDate, StartTime, EndTime, ShiftType FROM Shifts Where AssignedEmployeeID = ?";
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
        
    }
    
?>



<?php require('./shared/header.php') ?>

<!-- Body -->
<div class="container welcome-container">
    <table id="example" class="table table-hover table-dark">
    <thead>
        <tr>
        <th scope="col"></th>
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
<?php require('./shared/footer.php') ?>