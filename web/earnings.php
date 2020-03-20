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

$AttendedCount = 0;
// Get count of attended shifts for the current employee
$sql = "SELECT COUNT(*) FROM Shifts WHERE AssignedEmployeeID = ? and Attended = 1;";

if($stmt = mysqli_prepare($link, $sql)){
    
    mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
    // Attempt to execute the prepared statement
    if(mysqli_stmt_execute($stmt)){
        
        // Store result
        mysqli_stmt_store_result($stmt);
        $stmt->bind_result($count);
        

        if(mysqli_stmt_fetch($stmt)) {
            $AttendedCount = $count;
         }
    }else{
        echo "Oops! Something went wrong. Please try again later.";
    }
        // Close statement
        mysqli_stmt_close($stmt);
}

$totalCountShifts = 0;
$sql = "SELECT COUNT(*) FROM Shifts WHERE AssignedEmployeeID = ? ";

if($stmt = mysqli_prepare($link, $sql)){
    
    mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
    // Attempt to execute the prepared statement
    if(mysqli_stmt_execute($stmt)){
        
        // Store result
        mysqli_stmt_store_result($stmt);
        $stmt->bind_result($count);
        

        if(mysqli_stmt_fetch($stmt)) {
            $totalCountShifts = $count;
         }
    }else{
        echo "Oops! Something went wrong. Please try again later.";
    }
        // Close statement
        mysqli_stmt_close($stmt);
}





$HourlyRate = 0;
// Get HourlyRate for the current employee

$sql = "SELECT HourlyRate FROM Users Where ID = ?;";

if($stmt = mysqli_prepare($link, $sql)){
    
    mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
    // Attempt to execute the prepared statement
    if(mysqli_stmt_execute($stmt)){
        
        // Store result
        mysqli_stmt_store_result($stmt);
        $stmt->bind_result($wage);
        

        if(mysqli_stmt_fetch($stmt)) {
            $HourlyRate = $wage;
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


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Wage Statistics</title>

        <!-- Google Fonts -->
        <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet">

        <!-- Bootstrap 4.0 CSS -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

        <!-- Font Awesome Icons -->
        <script src="https://kit.fontawesome.com/03cf08f72f.js" crossorigin="anonymous"></script>

        <!-- JQuery 3.4.1 CDN -->
        
        <script src="https://code.jquery.com/jquery-3.4.1.js"  integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous"></script>

        <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

        <!-- Chart js -->
        <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.3/Chart.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/chart.js@2.8.0"></script>


        <!-- Ajax for dataset -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

        <link rel="stylesheet" href="./css/header-page.css">
        <link rel="stylesheet" href="./css/earnings-page.css">
</head>
<body>

<!-- Navbar -->
<?php require('./shared/header.php') ?>

<div class="container earnings-container">
        <div class="total-container">
            <div class="money tracking-in-expand">
                <h4> € </h4>
                <h2 ><?php echo ($HourlyRate* $AttendedCount);?></h2>
                <h3>00 </h3>
            </div>
            <div class="money-label text-focus-in">
                Total earnings
            </div>
        </div> 
        <div class="attendance-container">
            <div class="attendance  tracking-in-expand" data-toggle="tooltip" title="<?php echo "Your hourly wage is: ". $HourlyRate . " €"?>">
                    <h2><?php echo $AttendedCount;?></h2>
            </div>
            <div class="attendance-label text-focus-in">
                Attended shifts
            </div>
        </div>
</div>
<div class="container header-container">
    <h2>Statistics for your shifts</h2>
    <h4>Based on your current statistics, you can start booking sessions for the next week</h4>
</div>
<div class="container chart-container">
    <canvas id="myChart"></canvas>
</div>

<script>
    
    $(document).ready(function(){
        
        $.post("/includes/dataset.php",
                function (data)
                {
                    console.log(data);
                    var months = [];
                    var counts = [];

                    for (var i in data) {
                        months.push(data[i][0]);
                        
                        counts.push(data[i][1]);
                        
                    }

                    var chartdata = {
                        labels: months,
                        datasets: [
                            {                
                                label: 'Total Shifts <?php echo $totalCountShifts ?>',
                                backgroundColor: '#8899C5',
                                borderColor: '#8879C5',
                                data: counts
                            }
                        ]
                    };
                            
                var ctx = document.getElementById('myChart').getContext('2d');
                var chart = new Chart(ctx, {
                // The type of chart we want to create
                type: 'line',

                // The data for our dataset
                data: chartdata,

                // Configuration options go here
                options: {}
                });

                });

    });
</script>


</body>
</html>