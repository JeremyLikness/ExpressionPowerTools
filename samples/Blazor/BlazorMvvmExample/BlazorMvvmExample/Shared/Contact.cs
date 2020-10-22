// Copyright (c) Jeremy Likness. All rights reserved.
// Licensed under the MIT License. See LICENSE in the repository root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorMvvmExample.Shared
{
    /// <summary>
    /// Contact entity.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Gets or sets the contact unique identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the optional last name.
        /// </summary>
        [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 digits.")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the street address.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "Street cannot exceed 100 characters.")]
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters.")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state code.
        /// </summary>
        [Required]
        [StringLength(3, ErrorMessage = "State abbreviation cannot exceed 3 characters.")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        [Required]
        [RegularExpression(@"^\d{5}(?:[-\s]\d{4})?$", ErrorMessage = "Enter a valid zipcode in 55555 or 55555-5555 format")]
        public string ZipCode { get; set; }

        /// <summary>
        /// String representation.
        /// </summary>
        /// <returns>The string representation of the contact.</returns>
        public override string ToString() => $"{Id}: {LastName}, {FirstName} ({Phone}) {Street} {City}, {State} {ZipCode}";
    }
}
