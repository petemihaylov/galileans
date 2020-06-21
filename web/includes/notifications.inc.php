<?php 

// Adds the database configuration
require '../models/Notification.php';

$notificationArray = array();

// Preloads all of the shifts for the current user
$sql = "SELECT ID, Message, UserID FROM Notification Where UserID = ?";

if ($stmt = mysqli_prepare($link, $sql)) {

    mysqli_stmt_bind_param($stmt, "s", $_SESSION['id']);

    // Attempt to execute the prepared statement
    if (mysqli_stmt_execute($stmt)) {
        // Store result
        mysqli_stmt_store_result($stmt);

        $rows = mysqli_stmt_num_rows($stmt);

        for ($i = 0; $i < $rows; $i++) {

            mysqli_stmt_bind_result($stmt, $ID, $Message, $UserID);

            if (mysqli_stmt_fetch($stmt)) {
                $notification = new Notification($ID, $Message, $UserID);
                array_push($notificationArray, $notification);
            }
        }
    } else {
        echo "Oops! Something went wrong. Please try again later.";
    }

    mysqli_stmt_close($stmt);
}


// Closes the DB connection
mysqli_close($link);

?>

<div class="prompt">
    <h4>Messages</h4>

    <ul>
    <?php for ($i = 0; $i < count($notificationArray); $i++) {
        $item = $notificationArray[$i];?>
        <li><?php echo $item->get_Message(); ?></li>
    <?php } ?>
    </ul>
</div>

<script>
$(".userDrop").click(function () {
			$(".prompt").slideToggle( "show");
});
</script>