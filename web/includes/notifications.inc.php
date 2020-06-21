<?php 

// Adds the database configuration
require_once "../includes/config.inc.php";


?>

<div class="prompt">
    <h4>Messages</h4>
    <ul>
        <li>Cart Item One</li>
        <li>Cart Item Two</li>
        <li>Cart Item Three</li>
    </ul>
</div>

<script>
$(".userDrop").click(function () {
			$(".prompt").slideToggle( "show");
});
</script>