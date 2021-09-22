﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DTOs
{
    public class EmployeeDetailsDTO
    {
        // Manager anasayfa izin talepleri - doğum günleri - mesai talepleri - ödeme talepleri (adsoyad-tarih)
        // Manager çalışanlar sayfası (foto-adsoyad-title-numara)
        public int Id { get; set; }
        public string FullName { get; set; }
        public byte[] Photo { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }
        public DateTime Date { get; set; } 
    }
}
