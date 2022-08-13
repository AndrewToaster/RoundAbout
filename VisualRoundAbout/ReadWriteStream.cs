using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualRoundAbout
{
    public class NestedMemoryStream : Stream
    {
        public MemoryStream Inner { get; }
        private long _inner_pos;

        public NestedMemoryStream()
        {
            Inner = new();
        }

        public override void Flush()
        {
            Inner.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            Inner.Position = _inner_pos;
            var result = Inner.Read(buffer, offset, count);
            _inner_pos = Inner.Position;
            return result;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return Inner.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            Inner.Position = Position;
            Inner.Write(buffer, offset, count);
            Position = Inner.Position;
        }

        public override bool CanRead => true;
        public override bool CanSeek => true;
        public override bool CanWrite => true;
        public override long Length => Inner.Length;
        public override long Position { get; set; }
    }
}
