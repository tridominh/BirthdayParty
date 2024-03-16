using System;
using System.Collections.Generic;
using System.Linq;
using BirthdayParty.Models;
using BirthdayParty.Models.DTOs;
using BirthdayParty.Repository.Interfaces;
using BirthdayParty.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace BirthdayParty.Services
{
	public class BookingService : IBookingService
	{
		private readonly IGenericRepository<Booking> _bookingRepository;
		private readonly ILogger<BookingService> _logger;

		public BookingService(IGenericRepository<Booking> bookingRepository, ILogger<BookingService> logger)
		{
			_bookingRepository = bookingRepository;
			_logger = logger;
		}

		public List<Booking> GetAllBookings()
		{
			try
			{
				return _bookingRepository.GetAll().ToList();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error occurred while fetching all bookings: {ex.Message}");
				throw;
			}
		}

		public Booking CreateBooking(BookingDTO booking)
		{
			try
			{
				if (booking == null)
					throw new ArgumentNullException(nameof(booking), "Booking data cannot be null.");

				var book = new Booking
				{
					UserId = booking.UserId,
					RoomId = booking.RoomId,
					BookingDate = DateTime.UtcNow,
					PartyDateTime = booking.PartyDateTime,
					BookingStatus = booking.BookingStatus,
					Feedback = booking.Feedback,
				};

				_bookingRepository.Add(book);
				return book;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error occurred while creating a booking: {ex.Message}");
				throw;
			}
		}

		public Booking UpdateBooking(BookingDTO booking)
		{
			try
			{
				if (booking == null)
					throw new ArgumentNullException(nameof(booking), "Booking data cannot be null.");

				Booking existingBooking = _bookingRepository.Get(booking.BookingId.Value);

				if (existingBooking == null)
					throw new ArgumentException($"Booking with ID {booking.BookingId} not found.");

				existingBooking.UserId = booking.UserId;
				existingBooking.RoomId = booking.RoomId;
				existingBooking.BookingDate = DateTime.UtcNow;
				existingBooking.PartyDateTime = booking.PartyDateTime;
				existingBooking.BookingStatus = booking.BookingStatus;
				existingBooking.Feedback = booking.Feedback;

				_bookingRepository.Update(existingBooking);

				return existingBooking;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error occurred while updating a booking: {ex.Message}");
				throw;
			}
		}

		public Booking DeleteBooking(int id)
		{
			try
			{
				Booking booking = _bookingRepository.Delete(id);

				if (booking == null)
					throw new ArgumentException($"Booking with ID {id} not found.");

				return booking;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error occurred while deleting a booking: {ex.Message}");
				throw;
			}
		}
	}
}
