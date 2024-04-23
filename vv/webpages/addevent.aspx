<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addevent.aspx.cs" Inherits="vv.webpages.addevent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="../styles/eventspageStyles.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Coustard:wght@400;900&display=swap"
        rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <title>VV ADD EVENT PAGE </title>
</head>
<body>
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Add New Event</title>
        <link rel="stylesheet" href="styles.css">
    </head>
    <body>
        <div class="form-container">
            <form action="#" method="post">
                <div class="form-field">
                    <label for="title">TITLE</label>
                    <input type="text" id="title" name="title" required>
                    <div class="addlinks">
                        <div class="add-description">+ Add Description</div>
                        <div class="add-picture">+ Add Picture</div>
                    </div>
                </div>

                <div class="form-field">
                    <label for="date">DATE</label>
                    <input type="text" id="date" name="date" required>

                    <label for="time">TIME</label>
                    <div class="time-input">
                        <select name="hour" id="hour">
                            <option value="one" selected>01</option>
                            <option value="two">02</option>
                            <option value="three">03</option>
                            <option value="four">04</option>
                            <option value="five">05</option>
                            <option value="six">06</option>
                            <option value="seven">07</option>
                            <option value="eight">08</option>
                            <option value="nine">09</option>
                            <option value="ten">10</option>
                            <option value="eleven">11</option>
                            <option value="twelve">12</option>
                        </select>


                        <select name="minute" id="minute">
                            <option value="zero-mins" selected>00</option>
                            <option value="five-mins">05</option>
                            <option value="ten-mins">10</option>
                            <option value="fifteen-mins">15</option>
                            <option value="twenty-mins">20</option>
                            <option value="twentyfive-mins">25</option>
                            <option value="thirty-mins">30</option>
                            <option value="thirtyfive-mins">35</option>
                            <option value="forty-mins">40</option>
                            <option value="fortyfive-mins">45</option>
                            <option value="fifty-mins">50</option>
                            <option value="fiftyfive-mins">55</option>
                        </select>


                        <select name="ampm" id="ampm">
                            <option value="AM" selected>AM</option>
                            <option value="PM">PM</option>
                        </select>
                    </div>

                    <label for="duration">DURATION</label>
                    <div class="duration-input">
                        <input type="text" id="duration-hour" name="duration-hour" placeholder="H" required>
                        <input type="text" id="duration-minute" name="duration-minute" placeholder="M" required>
                    </div>
                </div>

                <div class="form-field">
                    <input type="radio" id="physical-event" name="event-type" value="physical" checked>
                    <label for="physical-event">Physical Event</label>
                    <input type="text" id="location" name="location" placeholder="Location" required>
                    <div class="add-room">+ Add Room</div>


                    <input type="radio" id="virtual-event" name="event-type" value="virtual">
                    <label for="virtual-event">Virtual Event</label>
                    <input type="text" id="link" name="link" placeholder="Link">
                </div>

                <div class="form-field">
                    <label for="tags">ADD TAGS</label>
                    <select name="tags" id="tags" multiple required>
                        <option value="tag1">Tag 1</option>
                        <option value="tag2">Tag 2</option>
                        <option value="tag3">Tag 3</option>
                        <option value="tag3">Tag 3</option>
                        <option value="tag3">Tag 3</option>
                        <option value="tag3">Tag 3</option>
                    </select>
                </div>

                <div class="form-field">
                    <input type="radio" id="co-organizers" name="co-organizers" value="yes">
                    <label for="co-organizers">Any Co-Organizers?</label>
                </div>
                <div class="form-field">
                    <button type="submit">ADD NEW EVENT</button>
                </div>
            </form>
        </div>
    </body>
    </html>

</body>
</html>
