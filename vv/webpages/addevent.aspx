<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addevent.aspx.cs" Inherits="vv.webpages.addevent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/headerfooterStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>VV ADD EVENT PAGE </title>
</head>
<body>
 <div class="form-container">
    <form>
      <div class="form-group">
        <label for="title">Title:</label>
        <input type="text" id="title" name="title">
        <div class="add-options">
          <span>+ Add description</span>
          <span>+ Add picture</span>
        </div>
      </div>

      <div class="form-group">
        <div class="date-time">
          <div class="date">
            <label for="date">Date:</label>
            <input type="date" id="date" name="date">
          </div>
          <div class="time">
            <label for="time">Time:</label>
            <input type="time" id="time" name="time">
          </div>
          <div class="duration">
            <label for="duration">Duration:</label>
            <input type="text" id="duration" name="duration">
          </div>
        </div>
      </div>

      <div class="form-group">
        <div class="event-type">
          <label>Event Type:</label>
          <div class="radio-group">
            <input type="radio" id="physical-event" name="event-type" value="physical">
            <label for="physical-event">Physical Event</label>
            <input type="text" id="location" name="location" placeholder="Location">
            <span>+ Add meeting room</span>
          </div>
          <div class="radio-group">
            <input type="radio" id="virtual-event" name="event-type" value="virtual" disabled>
            <label for="virtual-event">Virtual Event</label>
          </div>
        </div>
      </div>

      <div class="form-group">
        <label for="tags">Add Tags:</label>
        <input type="text" id="tags" name="tags">
      </div>

      <div class="form-group">
        <div class="co-organizers">
          <input type="checkbox" id="co-organizers" name="co-organizers">
          <label for="co-organizers">Add Co-Organizers?</label>
        </div>
      </div>

      <div class="form-group">
        <button type="submit">Submit</button>
      </div>
    </form>
  </div>
</body>
</html>
