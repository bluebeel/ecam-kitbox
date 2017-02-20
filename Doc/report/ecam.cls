\NeedsTeXFormat{LaTeX2e}
\ProvidesClass{ecam}[2016/10/13 v1.0 ECAM report]
\LoadClass[a4paper]{report}

\RequirePackage{graphicx}
\RequirePackage{overpic}
\RequirePackage[usenames,dvipsnames,svgnames,table]{xcolor}
\RequirePackage{transparent}
\RequirePackage{tcolorbox}
\RequirePackage{titlesec}
\RequirePackage[left=1.5cm,right=1.5cm,top=1.5cm,bottom=1.5cm]{geometry}

\let\@college\@empty
\let\@degree\@empty
\let\@university\@empty
\def\@logo{\includegraphics[width=40mm]{images/ecam.png}}
\def\@cover{\begin{overpic}[width=1.1\paperwidth]{images/electronics.jpg}\end{overpic}}
\newcommand{\logo}[1]{\gdef\@logo{\includegraphics[width=40mm]{#1}}}
\newcommand{\cover}[1]{\gdef\@cover{\begin{overpic}[width=\paperwidth]{#1}\end{overpic}}}
\newcommand{\college}[1][My School]{\gdef\@college{#1}}
\newcommand{\degree}[1][My degree]{\gdef\@degree{#1}}
\newcommand{\university}[1][My university]{\gdef\@university{#1}}

\renewcommand\maketitle{

  	\begin{titlepage}

      	\newgeometry{top=0cm, left=0cm, right=0cm}
      	\noindent
        \begin{center}
        \makebox[\textwidth]{
          	\hspace{-4pt}\@cover
      	}
        \end{center}
      	\vspace*{-6cm}
      	\begin{center}
          	%
          	\textsf{\textbf{\textcolor{white}{{\fontsize{42pt}{1pt}\selectfont\@title}}}}\par
          	\vspace*{5cm}
          	{\Large\bfseries\@author\par}
          	{\ifx\@college\@empty\else\large\vspace*{1ex}\par\@college\par\fi}
          	{\ifx\@university\@empty\else\large\@university\par\fi}
          	{\ifx\@degree\@empty\else\Large\itshape\@degree\par\fi}
          	\vspace*{2ex}
          	{\today}
        	{\vspace*{10mm}\par\@logo\par\vspace*{15mm}}
		\end{center}

  		\null\vfill


 	\end{titlepage}

	\newgeometry{top=2.5cm, left=3cm, right=3cm}
    \fontsize{12pt}{14pt}\selectfont\
}
\endinput
