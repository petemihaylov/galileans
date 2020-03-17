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
 
// Define variables and initialize with empty values
$fullname = $email = $password = "";
$fullname_err = $email_err = $password_err = "";
 
// Processing form data when form is submitted
if($_SERVER["REQUEST_METHOD"] == "POST"){
 
    // Check if email is empty
    if(empty(trim($_POST["email"]))){
        $email_err = "* Please enter email.";
    } else{
        $email = trim($_POST["email"]);
    }

    // Check if fullname is empty
    if(empty(trim($_POST["fullname"]))){
        $fullname_err = "* Please enter fullname.";
    } else{
        $fullname = trim($_POST["fullname"]);
    }
    

    // Check if password is empty
    if(empty(trim($_POST["password"]))){
        $password_err = "* Please enter your password.";
    } else{
        $password = trim($_POST["password"]);
    }
    
    // Validate credentials
    if(empty($email_err) && empty($password_err) && empty($fullname_err)){
        // Prepare a select statement
        $sql = "UPDATE Users SET FullName = ?, Email = ?, Password = ? WHERE ID=?; ";
        
        if($stmt = mysqli_prepare($link, $sql)){
            // Bind variables to the prepared statement as parameters
            mysqli_stmt_bind_param($stmt, "ssss", $fullname ,$email,  $param_password, $_SESSION['id']);
            
           $param_password = password_hash($password, PASSWORD_BCRYPT);
            
            // Attempt to execute the prepared statement
            if(!mysqli_stmt_execute($stmt)){
              echo "Oops! Something went wrong. Please try again later.";
            }

            // Close statement
            mysqli_stmt_close($stmt);
        }
    }
    
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
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css">
    <!-- Font Awesome Icons -->
    <script src="https://kit.fontawesome.com/03cf08f72f.js" crossorigin="anonymous"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"></script>
      

    
    <link rel="stylesheet" href="./css/header-page.css">
    <link rel="stylesheet" href="./css/welcome-page.css">
    
    <title>Details</title>
</head>
<body>


<?php require('./shared/header.php') ?>

<!-- Body -->
<div class="container details-container">
     <!-- Nav pills -->
    <ul class="nav nav-pills" role="tablist">
        <li class="nav-item">
        <a class="nav-link " data-toggle="pill" href="#details"><i class="fas fa-info-circle"></i></a>
        </li>
        <li class="nav-item">
        <a class="nav-link active" data-toggle="pill" href="#update">Update</a>
        </li>
    </ul>

    <div class="tab-content">
        <div id="details" class="container tab-pane fade"><br>
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
        <div id="update" class="container tab-pane active"><br>
            <div class="container">
                <h3>EDIT DETAILS</h3>
                <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post">
                    <div class="form-group">
                        <label for="fullname">Full Name:</label>
                        <input type="text" class="form-control" name="fullname" value="<?php echo $fullname; ?>" 
                        placeholder="<?php echo $user->get_FullName();?>">

                        
                        <span class="help-block"><?php echo $fullname_err; ?></span>
                    </div>
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="text" class="form-control" name="email" value="<?php echo $email; ?>"
                        placeholder="<?php echo $user->get_Email();?>">
                        
                         <span class="help-block"><?php echo $email_err; ?></span>
                    </div>
                    <div class="form-group" >
                        
                    <script src="./js/show-hide-password.js"></script>
                    <label for="pnm">Password:</label>
                    <div class="input-group" id="show_hide_password">
                        <input class="form-control" name="password" value="<?php echo $password; ?>" type="password"
                        
                        placeholder="<?php echo $password;?>">
                        <div class="input-group-append">
                            <a class="input-group-text"><i class="fa fa-eye-slash" aria-hidden="true"></i></a>
                        </div>
                    </div>

                        <span class="help-block"><?php echo $password_err; ?></span>
                    </div>
                    <button type="submit" class="btn btn-outline-primary">Update</button>
                </form>
            </div>
        </div>
    </div>

    
</div>
