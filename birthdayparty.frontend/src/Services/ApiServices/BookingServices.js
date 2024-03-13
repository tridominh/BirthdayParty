import getEndpoint from "../getEndpoint";

async function CreateBooking(booking) {
    //console.log(JSON.stringify(credentials))
    const res = await fetch(`${getEndpoint()}/api/Booking/Create`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Headers': '*',
        },
        body: JSON.stringify(booking)
    });
    return res;
}

export {
    CreateBooking
};
