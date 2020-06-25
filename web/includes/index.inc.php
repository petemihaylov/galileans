<?php
// Include config file
require_once "config.inc.php";


// Define variables and initialize with empty values
$email = $password = "";
$email_err = $password_err = "";
$focus = "";
$fullname = "";


// Processing form data when form is submitted
if ($_SERVER["REQUEST_METHOD"] == "POST") {

    // Check if email is empty
    if (empty(trim($_POST["email"]))) {
        $email_err = "* Please enter email.";
        $focus = "focus";
    } else {
        $email = trim($_POST["email"]);
    }

    // Check if password is empty
    if (empty(trim($_POST["password"]))) {
        $password_err = "* Please enter your password.";
        $focus = "focus";
    } else {
        $password = trim($_POST["password"]);
    }

    // Validate credentials
    if (empty($email_err) && empty($password_err)) {
        // Prepare a select statement
        $sql = "SELECT ID, FullName, Email, Password, Role FROM User WHERE Email = ?";

        if ($stmt = mysqli_prepare($link, $sql)) {
            // Bind variables to the prepared statement as parameters
            mysqli_stmt_bind_param($stmt, "s", $param_email);

            // Set parameters
            $param_email = $email;

            // Attempt to execute the prepared statement
            if (mysqli_stmt_execute($stmt)) {
                // Store result
                mysqli_stmt_store_result($stmt);

                // Check if email exists, if yes then verify password
                if (mysqli_stmt_num_rows($stmt) == 1) {
                    // Bind result variables
                    mysqli_stmt_bind_result($stmt, $id, $fullname, $email, $hashed_password, $role);
                    if (mysqli_stmt_fetch($stmt)) {
                        if (strtoupper($role) !== "ADMINISTRATOR") {

                            if (password_verify($password, $hashed_password)) {
                                // Password is correct, so start a new session
                                session_start();

                                // Store data in session variables
                                $_SESSION["loggedin"] = true;
                                $_SESSION["id"] = $id;
                                $_SESSION["email"] = $email;
                                $_SESSION["fullname"] = $fullname;

                                // Redirect user to welcome page
                                header("location: ./views/welcome.php");
                            } else {
                                // Display an error message if password is not valid
                                $password_err = "* The password you entered was not valid.";
                                $focus = "focus";
                            }
                        } else {
                            $email_err = "* Sorry! You are not authorized!";
                            $focus = "focus";
                        }
                    }
                } else {
                    // Display an error message if email doesn't exist
                    $email_err = "* No account found with that email.";
                    $focus = "focus";
                }
            } else {
                echo "Oops! Something went wrong. Please try again later.";
            }

            // Close statement
            mysqli_stmt_close($stmt);
        }
    } else {
        $password_err = "* SQL db error";
    }

    // Close connection
    mysqli_close($link);
}



?>