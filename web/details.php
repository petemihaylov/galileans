<?php
// Initialize the session
session_start();
 
// Check if the user is logged in, if not then redirect him to login page
if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
    header("location: index.php");
    exit;
}

// Include config file
require "./includes/config.php";
require "./models/User.php";
require "./models/Shift.php";



 // Prepare a select statement
 $sql = "SELECT ID, FullName, Email, Password, PhoneNumber, Role, HourlyRate FROM Users Where ID = ?";
    if($stmt = mysqli_prepare($link, $sql)){
    
        mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);
        
        // Attempt to execute the prepared statement
        if(mysqli_stmt_execute($stmt)){
            // Store result
            mysqli_stmt_store_result($stmt);
            
                    mysqli_stmt_bind_result($stmt, $ID, $FullName, $Email, $Password, $PhoneNumber, $Role, $HourlyRate);
                    
                    if(mysqli_stmt_fetch($stmt)){
                           $user = new User($ID, $FullName, $Email, $Password, $PhoneNumber, $Role, $HourlyRate);
                    }
        }else{
            echo "Oops! Something went wrong. Please try again later.";
        }
    }
?>

<?php require('./shared/header.php') ?>

<!-- Body -->
<div class="container details-container">
     <!-- Nav pills -->
    <ul class="nav nav-pills" role="tablist">
        <li class="nav-item">
        <a class="nav-link active" data-toggle="pill" href="#details"><i class="fas fa-info-circle"></i></a>
        </li>
        <li class="nav-item">
        <a class="nav-link" data-toggle="pill" href="#update">Update</a>
        </li>
    </ul>

    <div class="tab-content">
        <div id="details" class="container tab-pane active"><br>
            <div class="container">
                <h3>PERSONAL DETAILS</h3><br>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item">Fullname: <?php echo $user->get_FullName();?></li>
                    <li class="list-group-item">Email: <?php echo $user->get_Email();?></li>
                    <li class="list-group-item">Role: <?php echo $user->get_Role();?></li>
                    <li class="list-group-item">Wage per hour: <?php echo $user->get_HourlyRate();?>$</li>
                </ul>
            </div>
        </div>
        <div id="update" class="container tab-pane fade"><br>
            <div class="container">
                <h3>EDIT DETAILS</h3>
                <form action="#">
                    <div class="form-group">
                        <label for="fullname">Full Name:</label>
                        <input type="text" class="form-control" name="fullname">
                    </div>
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="text" class="form-control" name="email">
                    </div>
                    <div class="form-group">
                        <label for="pnm">Password:</label>
                        <input type="password" name="password" class="form-control" id="usr" name="fullname">
                    </div>
                    <button type="submit" class="btn btn-outline-primary">Update</button>
                </form>
            </div>
        </div>
    </div>

    
</div>

<!-- Footer -->
<?php require('./shared/footer.php') ?>