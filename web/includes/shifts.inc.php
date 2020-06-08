<?php
$shiftArray = array();

// Preloads all of the shifts for the current user
$sql = "SELECT ID, ShiftDate, StartTime, EndTime, ShiftType FROM Shift Where AssignedUserID = ?";
if ($stmt = mysqli_prepare($link, $sql)) {

    mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);

    // Attempt to execute the prepared statement
    if (mysqli_stmt_execute($stmt)) {
        // Store result
        mysqli_stmt_store_result($stmt);

        $rows = mysqli_stmt_num_rows($stmt);

        for ($i = 0; $i < $rows; $i++) {

            mysqli_stmt_bind_result($stmt, $ID, $ShiftDate, $StartTime, $EndTime, $ShiftType);

            if (mysqli_stmt_fetch($stmt)) {
                $shift = new Shift($ID, $ShiftDate, $StartTime, $EndTime, $ShiftType);
                array_push($shiftArray, $shift);
            }
        }
    } else {
        echo "Oops! Something went wrong. Please try again later.";
    }

    mysqli_stmt_close($stmt);
}

?>