using Ccr.Html.Attributes;
using Ccr.Html.Tags;
using Ccr.Html.Tags.Infrastructure;

namespace Ccr.Html.Builders
{
	public static class HtmlBuilderTagExtensions
	{
		public static HtmlBuilder<A, HtmlBuilder<TTag, TBuilder>> A<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder,
			string href)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new A(href));
		}

		public static HtmlBuilder<Abbr, HtmlBuilder<TTag, TBuilder>> Abbr<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Abbr());
		}

		public static HtmlBuilder<Address, HtmlBuilder<TTag, TBuilder>> Address<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
			where TTag : Tag
			where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Address());
		}

		public static HtmlBuilder<Area, HtmlBuilder<TTag, TBuilder>> Area<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Area());
		}

		public static HtmlBuilder<Article, HtmlBuilder<TTag, TBuilder>> Article<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Article());
		}

		public static HtmlBuilder<Aside, HtmlBuilder<TTag, TBuilder>> Aside<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Aside());
		}

		public static HtmlBuilder<Audio, HtmlBuilder<TTag, TBuilder>> Audio<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Audio());
		}

		public static HtmlBuilder<B, HtmlBuilder<TTag, TBuilder>> B<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new B());
		}

		public static HtmlBuilder<Base, HtmlBuilder<TTag, TBuilder>> Base<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder,
			string href, 
			Target? target = null)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Base(href, target));
		}

		public static HtmlBuilder<Base, HtmlBuilder<TTag, TBuilder>> Base<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder, 
			Target target)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Base(target));
		}

		public static HtmlBuilder<Bdi, HtmlBuilder<TTag, TBuilder>> Bdi<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Bdi());
		}

		public static HtmlBuilder<Bdo, HtmlBuilder<TTag, TBuilder>> Bdo<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder, Dir dir)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Bdo(dir));
		}

		public static HtmlBuilder<Blockquote, HtmlBuilder<TTag, TBuilder>> Blockquote<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Blockquote());
		}

		public static HtmlBuilder<Body, HtmlBuilder<TTag, TBuilder>> Body<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Body());
		}

		public static HtmlBuilder<Br, HtmlBuilder<TTag, TBuilder>> Br<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Br());
		}

		public static HtmlBuilder<Button, HtmlBuilder<TTag, TBuilder>> Button<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder, ButtonType type)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Button(type));
		}

		public static HtmlBuilder<Canvas, HtmlBuilder<TTag, TBuilder>> Canvas<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Canvas());
		}

		public static HtmlBuilder<Caption, HtmlBuilder<TTag, TBuilder>> Caption<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Caption());
		}

		public static HtmlBuilder<Col, HtmlBuilder<TTag, TBuilder>> Col<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Col());
		}

		public static HtmlBuilder<Colgroup, HtmlBuilder<TTag, TBuilder>> Colgroup<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Colgroup());
		}

		public static HtmlBuilder<Cite, HtmlBuilder<TTag, TBuilder>> Cite<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Cite());
		}

		public static HtmlBuilder<Code, HtmlBuilder<TTag, TBuilder>> Code<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Code());
		}

		public static HtmlBuilder<Data, HtmlBuilder<TTag, TBuilder>> Data<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder, 
			string value)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Data(value));
		}

		public static HtmlBuilder<Datalist, HtmlBuilder<TTag, TBuilder>> Datalist<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
			where TTag : Tag
			where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Datalist());
		}

		public static HtmlBuilder<Dd, HtmlBuilder<TTag, TBuilder>> Dd<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Dd());
		}

		public static HtmlBuilder<Del, HtmlBuilder<TTag, TBuilder>> Del<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Del());
		}

		public static HtmlBuilder<Details, HtmlBuilder<TTag, TBuilder>> Details<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Details());
		}

		public static HtmlBuilder<Dfn, HtmlBuilder<TTag, TBuilder>> Dfn<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Dfn());
		}

		public static HtmlBuilder<Div, HtmlBuilder<TTag, TBuilder>> Div<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Div());
		}

		public static HtmlBuilder<Dl, HtmlBuilder<TTag, TBuilder>> Dl<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Dl());
		}

		public static HtmlBuilder<Dt, HtmlBuilder<TTag, TBuilder>> Dt<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Dt());
		}

		public static HtmlBuilder<Em, HtmlBuilder<TTag, TBuilder>> Em<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
			where TTag : Tag
			where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Em());
		}

		public static HtmlBuilder<Embed, HtmlBuilder<TTag, TBuilder>> Embed<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder, 
			string src)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Embed(src));
		}

		public static HtmlBuilder<Figcaption, HtmlBuilder<TTag, TBuilder>> Figcaption<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Figcaption());
		}

		public static HtmlBuilder<Figure, HtmlBuilder<TTag, TBuilder>> Figure<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Figure());
		}

		public static HtmlBuilder<Fieldset, HtmlBuilder<TTag, TBuilder>> Fieldset<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Fieldset());
		}

		public static HtmlBuilder<Footer, HtmlBuilder<TTag, TBuilder>> Footer<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Footer());
		}

		public static HtmlBuilder<Form, HtmlBuilder<TTag, TBuilder>> Form<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Form());
		}

		public static HtmlBuilder<H1, HtmlBuilder<TTag, TBuilder>> H1<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new H1());
		}

		public static HtmlBuilder<H2, HtmlBuilder<TTag, TBuilder>> H2<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new H2());
		}

		public static HtmlBuilder<H3, HtmlBuilder<TTag, TBuilder>> H3<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new H3());
		}

		public static HtmlBuilder<H4, HtmlBuilder<TTag, TBuilder>> H4<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new H4());
		}

		public static HtmlBuilder<H5, HtmlBuilder<TTag, TBuilder>> H5<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new H5());
		}

		public static HtmlBuilder<H6, HtmlBuilder<TTag, TBuilder>> H6<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new H6());
		}

		public static HtmlBuilder<Head, HtmlBuilder<TTag, TBuilder>> Head<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Head());
		}

		public static HtmlBuilder<Tags.Html, HtmlBuilder<TTag, TBuilder>> Html<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Tags.Html());
		}

		public static HtmlBuilder<I, HtmlBuilder<TTag, TBuilder>> I<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new I());
		}

		public static HtmlBuilder<Iframe, HtmlBuilder<TTag, TBuilder>> Iframe<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder,
			string src)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Iframe(src));
		}

		public static HtmlBuilder<Img, HtmlBuilder<TTag, TBuilder>> Img<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder,
			string src, 
			string alt)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Img(src, alt));
		}

		public static HtmlBuilder<Input, HtmlBuilder<TTag, TBuilder>> Input<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder,
			InputType inputType)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Input(inputType));
		}

		public static HtmlBuilder<Ins, HtmlBuilder<TTag, TBuilder>> Ins<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Ins());
		}

		public static HtmlBuilder<Kbd, HtmlBuilder<TTag, TBuilder>> Kbd<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
			where TTag : Tag
			where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Kbd());
		}

		public static HtmlBuilder<Label, HtmlBuilder<TTag, TBuilder>> Label<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Label());
		}

		public static HtmlBuilder<Legend, HtmlBuilder<TTag, TBuilder>> Legend<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
			where TTag : Tag
			where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Legend());
		}

		public static HtmlBuilder<Li, HtmlBuilder<TTag, TBuilder>> Li<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Li());
		}

		public static HtmlBuilder<Link, HtmlBuilder<TTag, TBuilder>> Link<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder, 
			string href)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Link(href));
		}

		public static HtmlBuilder<Main, HtmlBuilder<TTag, TBuilder>> Main<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Main());
		}

		public static HtmlBuilder<Map, HtmlBuilder<TTag, TBuilder>> Map<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
			where TTag : Tag
			where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Map());
		}

		public static HtmlBuilder<Mark, HtmlBuilder<TTag, TBuilder>> Mark<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Mark());
		}

		public static HtmlBuilder<Meta, HtmlBuilder<TTag, TBuilder>> Meta<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Meta());
		}

		public static HtmlBuilder<Meter, HtmlBuilder<TTag, TBuilder>> Meter<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder, double value)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Meter(value));
		}

		public static HtmlBuilder<Nav, HtmlBuilder<TTag, TBuilder>> Nav<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Nav());
		}

		public static HtmlBuilder<Noscript, HtmlBuilder<TTag, TBuilder>> Noscript<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Noscript());
		}

		public static HtmlBuilder<Tags.Object, HtmlBuilder<TTag, TBuilder>> Object<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Tags.Object());
		}

		public static HtmlBuilder<Ol, HtmlBuilder<TTag, TBuilder>> Ol<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Ol());
		}

		public static HtmlBuilder<Optgroup, HtmlBuilder<TTag, TBuilder>> Optgroup<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Optgroup());
		}

		public static HtmlBuilder<Option, HtmlBuilder<TTag, TBuilder>> Option<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Option());
		}

		public static HtmlBuilder<Output, HtmlBuilder<TTag, TBuilder>> Output<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Output());
		}

		public static HtmlBuilder<P, HtmlBuilder<TTag, TBuilder>> P<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new P());
		}

		public static HtmlBuilder<Param, HtmlBuilder<TTag, TBuilder>> Param<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Param());
		}

		public static HtmlBuilder<Picture, HtmlBuilder<TTag, TBuilder>> Picture<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Picture());
		}

		public static HtmlBuilder<Pre, HtmlBuilder<TTag, TBuilder>> Pre<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Pre());
		}

		public static HtmlBuilder<Progress, HtmlBuilder<TTag, TBuilder>> Progress<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Progress());
		}

		public static HtmlBuilder<Q, HtmlBuilder<TTag, TBuilder>> Q<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Q());
		}

		public static HtmlBuilder<Rp, HtmlBuilder<TTag, TBuilder>> Rp<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Rp());
		}

		public static HtmlBuilder<Rt, HtmlBuilder<TTag, TBuilder>> Rt<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Rt());
		}

		public static HtmlBuilder<Ruby, HtmlBuilder<TTag, TBuilder>> Ruby<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Ruby());
		}

		public static HtmlBuilder<S, HtmlBuilder<TTag, TBuilder>> S<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new S());
		}

		public static HtmlBuilder<Samp, HtmlBuilder<TTag, TBuilder>> Samp<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Samp());
		}

		public static HtmlBuilder<ExternalScript, HtmlBuilder<TTag, TBuilder>> ExternalScript<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder, 
			string src)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new ExternalScript(src));
		}

		public static HtmlBuilder<InlineScript, HtmlBuilder<TTag, TBuilder>> InlineScript<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder,
			string scriptSource)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new InlineScript(scriptSource));
		}

		public static HtmlBuilder<Section, HtmlBuilder<TTag, TBuilder>> Section<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Section());
		}

		public static HtmlBuilder<Select, HtmlBuilder<TTag, TBuilder>> Select<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Select());
		}

		public static HtmlBuilder<Small, HtmlBuilder<TTag, TBuilder>> Small<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Small());
		}

		public static HtmlBuilder<Source, HtmlBuilder<TTag, TBuilder>> Source<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Source());
		}

		public static HtmlBuilder<Span, HtmlBuilder<TTag, TBuilder>> Span<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Span());
		}

		public static HtmlBuilder<Strong, HtmlBuilder<TTag, TBuilder>> Strong<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Strong());
		}

		public static HtmlBuilder<Style, HtmlBuilder<TTag, TBuilder>> Style<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Style());
		}

		public static HtmlBuilder<Sub, HtmlBuilder<TTag, TBuilder>> Sub<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Sub());
		}

		public static HtmlBuilder<Summary, HtmlBuilder<TTag, TBuilder>> Summary<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Summary());
		}

		public static HtmlBuilder<Sup, HtmlBuilder<TTag, TBuilder>> Sup<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
			where TTag : Tag
			where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Sup());
		}

		public static HtmlBuilder<Table, HtmlBuilder<TTag, TBuilder>> Table<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Table());
		}

		public static HtmlBuilder<Tbody, HtmlBuilder<TTag, TBuilder>> Tbody<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Tbody());
		}

		public static HtmlBuilder<Td, HtmlBuilder<TTag, TBuilder>> Td<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Td());
		}

		public static HtmlBuilder<Template, HtmlBuilder<TTag, TBuilder>> Template<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Template());
		}

		public static HtmlBuilder<Textarea, HtmlBuilder<TTag, TBuilder>> Textarea<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Textarea());
		}

		public static HtmlBuilder<Tfoot, HtmlBuilder<TTag, TBuilder>> Tfoot<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Tfoot());
		}

		public static HtmlBuilder<Th, HtmlBuilder<TTag, TBuilder>> Th<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Th());
		}

		public static HtmlBuilder<Thead, HtmlBuilder<TTag, TBuilder>> Thead<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Thead());
		}

		public static HtmlBuilder<Time, HtmlBuilder<TTag, TBuilder>> Time<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Time());
		}

		public static HtmlBuilder<Title, HtmlBuilder<TTag, TBuilder>> Title<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Title());
		}

		public static HtmlBuilder<Tr, HtmlBuilder<TTag, TBuilder>> Tr<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Tr());
		}

		public static HtmlBuilder<Track, HtmlBuilder<TTag, TBuilder>> Track<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Track());
		}

		public static HtmlBuilder<U, HtmlBuilder<TTag, TBuilder>> U<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new U());
		}

		public static HtmlBuilder<Ul, HtmlBuilder<TTag, TBuilder>> Ul<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Ul());
		}

		public static HtmlBuilder<Var, HtmlBuilder<TTag, TBuilder>> Var<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Var());
		}

		public static HtmlBuilder<Video, HtmlBuilder<TTag, TBuilder>> Video<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Video());
		}

		public static HtmlBuilder<Wbr, HtmlBuilder<TTag, TBuilder>> Wbr<TTag, TBuilder>(
			this HtmlBuilder<TTag, TBuilder> builder)
				where TTag : Tag
				where TBuilder : HtmlBuilder
		{
			return builder.AddTagIfAllowed(new Wbr());
		}
	}
}