using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualRoundAbout
{
    public class ListenWriteStream : Stream
    {
        private readonly List<byte> bytes = new();

        public override void Flush()
        {
            if (bytes.Count == 0)
                return;

            Flushed?.Invoke(bytes.ToArray());
            bytes.Clear();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            bytes.AddRange(buffer[offset..(offset + count)]);
            Flush();
        }

        public override bool CanRead => false;
        public override bool CanSeek => false;
        public override bool CanWrite => true;
        public override long Length { get; }
        public override long Position { get; set; }

        public event Action<byte[]>? Flushed;
    }
}
