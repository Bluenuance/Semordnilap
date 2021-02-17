# Semordnilap

	Tests
	 > fasta tests (stream from string?)

    public static Stream ToStream(this string str)
    {
        MemoryStream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(str);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }

  add xamarin.forms
  all to xamarin (/"maui")